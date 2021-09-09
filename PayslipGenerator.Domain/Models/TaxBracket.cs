namespace PayslipGenerator.Domain.Models
{
    public class TaxBracket
    {
        public int LowerLimit { get; set; }
        public int HigherLimit { get; set; }
        public decimal TaxRate { get; set; }
    }
}
