namespace PayslipGenerator.Domain.Models
{
    public class TaxBracket
    {
        public decimal LowerLimit { get; set; }
        public decimal HigherLimit { get; set; } 
        public decimal TaxRate { get; set; }
    }
}
