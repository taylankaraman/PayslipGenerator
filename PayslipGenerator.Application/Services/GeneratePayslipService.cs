using System;
using System.Linq;
using System.Reflection.Emit;
using PayslipGenerator.Domain.Models;
using PayslipGenerator.Application.Interfaces;

namespace PayslipGenerator.Application.Services
{
    public class GeneratePayslipService : IGeneratePayslipService
    {
        public Payslip CreatePayslip(Employee employee, TaxTable taxTable)
        {

            decimal totalAnnualTax = 0m;



            foreach (var taxBracket in taxTable.TaxBrackets.OrderBy(o => o.LowerLimit))
            {
                if (employee.AnnualSalary <= taxBracket.LowerLimit) continue;

                var taxableAmountInBracket = Math.Min(employee.AnnualSalary - taxBracket.LowerLimit, taxBracket.HigherLimit - taxBracket.LowerLimit);
                var taxInBracket = taxableAmountInBracket * taxBracket.TaxRate;
                totalAnnualTax += taxInBracket;
            }

            var payslip = new Payslip
            {
                Name = employee.Name,
                GrossMonthlyIncome = employee.AnnualSalary / 12,
                MonthlyIncomeTax = totalAnnualTax / 12,
                NetMonthlyIncome = (employee.AnnualSalary / 12) - (totalAnnualTax / 12)
            };

            return payslip;
        }
    }
}
