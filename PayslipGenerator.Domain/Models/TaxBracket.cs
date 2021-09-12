namespace PayslipGenerator.Domain.Models
{
    public class TaxBracket
    {
        public int Id { get; set; }
        public decimal LowerLimit { get; set; }
        public decimal HigherLimit { get; set; } 
        public decimal TaxRate { get; set; }
    }
}
