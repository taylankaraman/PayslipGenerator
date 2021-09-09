namespace PayslipGenerator.Domain.Models
{
    public class Payslip
    {
        public string Name { get; set; }
        public decimal GrossMonthlyIncome { get; set; }
        public decimal MonthlyIncomeTax { get; set; }
        public decimal NetMonthlyIncome { get; set; }
    }
}
