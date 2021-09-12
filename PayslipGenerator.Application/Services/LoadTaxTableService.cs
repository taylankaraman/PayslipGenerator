using System.Linq;
using PayslipGenerator.Application.Interfaces;
using PayslipGenerator.Domain.Models;
using PayslipGenerator.Persistence;

namespace PayslipGenerator.Application.Services
{
    public class LoadTaxTableService : ILoadTaxTableService
    {
        private readonly PayslipGeneratorContext _context;

        public LoadTaxTableService(PayslipGeneratorContext context)
        {
            _context = context;
        }

        public TaxTable ReadTaxTable()
        {
            var taxTable = _context.TaxTables.FirstOrDefault(tt => tt.TableName == "TaxTable1");
            return taxTable;
;        }
    }
}
