using System.IO;
using System.Reflection;
using PayslipGenerator.Application.Interfaces;

namespace PayslipGenerator.Application.Services
{
    public class LoadTaxTableService : ILoadTaxTableService
    {
        public string ReadTaxTable()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "TaxTable.json");
            using StreamReader r = new StreamReader(path);
            string json = r.ReadToEnd();

            return json;
        }
    }
}
