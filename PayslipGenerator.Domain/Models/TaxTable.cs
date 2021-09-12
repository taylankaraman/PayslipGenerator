using System.Collections.Generic;

namespace PayslipGenerator.Domain.Models
{
    public class TaxTable
    {
        public int Id { get; set; }
        public string TableName { get; set; }
        public List<TaxBracket> TaxBrackets { get; set; }
    }
}
