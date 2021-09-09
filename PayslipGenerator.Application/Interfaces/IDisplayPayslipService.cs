using PayslipGenerator.Domain.Models;

namespace PayslipGenerator.Application.Interfaces
{
    public interface IDisplayPayslipService
    {
        public void PrintPayslip(Payslip payslip);
    }
}
