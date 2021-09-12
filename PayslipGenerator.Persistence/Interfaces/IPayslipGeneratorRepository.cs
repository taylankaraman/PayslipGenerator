using PayslipGenerator.Domain.Models;

namespace PayslipGenerator.Persistence.Interfaces
{
    public interface IPayslipGeneratorRepository
    {
        TaxTable GetTaxTableByName(string taxTableName);
    }
}
