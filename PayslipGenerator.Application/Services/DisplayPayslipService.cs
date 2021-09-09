using System;
using System.Globalization;
using PayslipGenerator.Domain.Models;
using PayslipGenerator.Application.Interfaces;

namespace PayslipGenerator.Application.Services
{
    public class DisplayPayslipService : IDisplayPayslipService
    {
        public void PrintPayslip(Payslip payslip)
        {
            Console.WriteLine("Monthly Payslip for: \"{0}\"", payslip.Name);
            Console.WriteLine("Gross Monthly Income: {0}", payslip.GrossMonthlyIncome.ToString("C", CultureInfo.CurrentCulture));
            Console.WriteLine("Monthly Income Tax: {0}", payslip.MonthlyIncomeTax.ToString("C", CultureInfo.CurrentCulture));
            Console.WriteLine("Net Monthly Income: {0}", payslip.NetMonthlyIncome.ToString("C", CultureInfo.CurrentCulture));
        }
    }
}
