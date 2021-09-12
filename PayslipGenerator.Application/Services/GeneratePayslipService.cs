using System;
using System.Linq;
using PayslipGenerator.Domain.Models;
using PayslipGenerator.Application.Interfaces;
using PayslipGenerator.Persistence.Interfaces;

namespace PayslipGenerator.Application.Services
{
    public class GeneratePayslipService : IGeneratePayslipService
    {
        private IPayslipGeneratorRepository _repo;

        public GeneratePayslipService(IPayslipGeneratorRepository repo)
        {
            _repo = repo;
        }

        public Payslip CreatePayslip(Employee employee, string taxTableName)
        {
            var taxTable = _repo.GetTaxTableByName(taxTableName);

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
