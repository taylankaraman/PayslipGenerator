using PayslipGenerator.Domain.Models;

namespace PayslipGenerator.Application.Interfaces
{
    public interface ILoadTaxTableService
    {
        public TaxTable ReadTaxTable();
    }
}
