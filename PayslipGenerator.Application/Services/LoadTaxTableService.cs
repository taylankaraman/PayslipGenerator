using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using PayslipGenerator.Application.Interfaces;
using PayslipGenerator.Domain.Models;

namespace PayslipGenerator.Application.Services
{
    public class LoadTaxTableService : ILoadTaxTableService
    {
        public TaxTable ReadTaxTable()
        {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "TaxTable.json");
            using var r = new StreamReader(path);
            var taxTableJson = r.ReadToEnd();

            var taxTable = JsonConvert.DeserializeObject<TaxTable>(taxTableJson);

            return taxTable;
;        }
    }
}
