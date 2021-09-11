using System;

namespace PayslipGenerator.Domain.Models
{
    public class TaxBracket
    {
        public decimal LowerLimit { get; set; }
        public decimal HigherLimit { get; set; } 
        public decimal TaxRate { get; set; }

        //public TYPE sortorder { get; set; }
        //load tax manage exception, json file is invalid or empty
    }
}
