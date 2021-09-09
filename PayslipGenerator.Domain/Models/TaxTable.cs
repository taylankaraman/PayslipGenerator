using System.Collections.Generic;

namespace PayslipGenerator.Domain.Models
{
    public class TaxTable
    {
        public List<TaxBracket> TaxBrackets { get; set; }
    }
}
