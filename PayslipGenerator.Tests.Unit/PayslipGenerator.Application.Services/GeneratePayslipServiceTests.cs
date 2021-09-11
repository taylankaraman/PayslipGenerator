using System;
using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using NUnit.Framework;
using PayslipGenerator.Application.Services;
using PayslipGenerator.Domain.Models;

namespace PayslipGenerator.Tests.Unit.PayslipGenerator.Application.Services
{
    public class GeneratePayslipServiceTests : BaseTests
    {
        private const decimal GrossAnnualSalary = 60000m;
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

        [Test]
        public void GivenGrossAnnualSalaryReturnsNetMonthlySalary()
        {
            // Arrange
            var generatePayslipService = new GeneratePayslipService();
            var employee = Fixture.Build<Employee>()
                .With(e => e.Name, "Mary Song")
                .With(e => e.AnnualSalary, 60000m)
                .Create();



            // Act
            var payslip = generatePayslipService.CreatePayslip(employee, _taxTable);

            // Assert
            Assert.AreEqual(payslip.Name, employee.Name);
            Assert.AreEqual(payslip.GrossMonthlyIncome, employee.AnnualSalary / 12);
            Assert.AreEqual(payslip.MonthlyIncomeTax, 500);
            Assert.AreEqual(payslip.NetMonthlyIncome, 4500);
        }
    }
}
