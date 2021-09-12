using System.Collections.Generic;

namespace PayslipGenerator.Domain.Models
{
    public class TaxTable
    {
        public int Id { get; set; }
        public string TaxTableName { get; set; }
        public List<TaxBracket> TaxBrackets { get; set; }
    }
}
