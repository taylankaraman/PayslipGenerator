﻿using System.Collections.Generic;
using AutoFixture;
using NUnit.Framework;
using PayslipGenerator.Application.Services;
using PayslipGenerator.Domain.Models;

namespace PayslipGenerator.Tests.Unit.PayslipGenerator.Application.Services
{
    public class GeneratePayslipServiceTests : BaseTests
    {
        private TaxTable _taxTable;

        [SetUp]
        public void Setup()
        {
            Fixture = new Fixture();

            var taxBracket1 = Fixture.Build<TaxBracket>()
                .With(t => t.LowerLimit, 0)
                .With(t => t.HigherLimit, 20000)
                .With(t => t.TaxRate, 0)
                .Create();

            var taxBracket2 = Fixture.Build<TaxBracket>()
                .With(t => t.LowerLimit, 20000)
                .With(t => t.HigherLimit, 40000)
                .With(t => t.TaxRate, 0.1m)
                .Create();

            var taxBracket3 = Fixture.Build<TaxBracket>()
                .With(t => t.LowerLimit, 40000)
                .With(t => t.HigherLimit, 80000)
                .With(t => t.TaxRate, 0.2m)
                .Create();

            var taxBracket4 = Fixture.Build<TaxBracket>()
                .With(t => t.LowerLimit, 80000)
                .With(t => t.HigherLimit, 180000)
                .With(t => t.TaxRate, 0.3m)
                .Create();

            var taxBracket5 = Fixture.Build<TaxBracket>()
                .With(t => t.LowerLimit, 180000)
                .With(t => t.HigherLimit, decimal.MaxValue)
                .With(t => t.TaxRate, 0.4m)
                .Create();

            var taxBrackets = new List<TaxBracket>
            {
                taxBracket1,
                taxBracket2,
                taxBracket3,
                taxBracket4,
                taxBracket5
            };

            _taxTable = Fixture.Build<TaxTable>()
                .With(tt => tt.TaxBrackets,taxBrackets)
                .Create();

        }

        [TestCase(20000, 0, 1666.67)]
        [TestCase(35000, 125, 2791.67)]
        [TestCase(40000, 166.67, 3166.67)]
        [TestCase(60000, 500, 4500)]
        [TestCase(80000, 833.33, 5833.33)]
        [TestCase(120000, 1833.33, 8166.67)]
        [TestCase(200000, 4000, 12666.67)]
        public void GivenGrossAnnualSalaryReturnsNetMonthlySalary(decimal grossAnnualSalary, decimal monthlyIncomeTax, decimal netMonthlyIncome)
        {
            // Arrange
            var generatePayslipService = new GeneratePayslipService();
            var employee = Fixture.Build<Employee>()
                .With(e => e.Name, "Mary Song")
                .With(e => e.AnnualSalary, grossAnnualSalary)
                .Create();


            // Act
            var payslip = generatePayslipService.CreatePayslip(employee, _taxTable);

            // Assert
            Assert.AreEqual(payslip.Name, employee.Name);
            Assert.AreEqual(payslip.GrossMonthlyIncome, employee.AnnualSalary / 12);
            Assert.That(payslip.MonthlyIncomeTax, Is.EqualTo(monthlyIncomeTax).Within(.01));
            Assert.That(payslip.NetMonthlyIncome, Is.EqualTo(netMonthlyIncome).Within(.01));
        }
    }
}
