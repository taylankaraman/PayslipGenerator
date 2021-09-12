using PayslipGenerator.Domain.Models;

namespace PayslipGenerator.Application.Interfaces
{
    public interface IGeneratePayslipService
    {
        public Payslip CreatePayslip(Employee employee, string taxTableName);
    }
}
