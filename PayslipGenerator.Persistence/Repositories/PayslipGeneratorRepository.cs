using System.Linq;
using PayslipGenerator.Domain.Models;
using PayslipGenerator.Persistence.Interfaces;

namespace PayslipGenerator.Persistence.Repositories
{
    public class PayslipGeneratorRepository : IPayslipGeneratorRepository
    {
        private PayslipGeneratorContext _context;
        public PayslipGeneratorRepository(PayslipGeneratorContext context)
        {
            _context = context;
        }
        public TaxTable GetTaxTableByName(string taxTableName)
        {
            return _context.TaxTables.FirstOrDefault(tt => tt.TaxTableName == taxTableName);
        }
    }
}
