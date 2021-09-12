using Microsoft.EntityFrameworkCore;
using PayslipGenerator.Domain.Models;

namespace PayslipGenerator.Persistence
{
    public class PayslipGeneratorContext : DbContext
    {
        public PayslipGeneratorContext(DbContextOptions<PayslipGeneratorContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaxBracket>()
                .HasKey(tb => tb.Id);
            
            modelBuilder.Entity<TaxTable>()
                .HasKey(tt => tt.Id);
        }

        public DbSet<TaxTable> TaxTables { get; set; }
        public DbSet<TaxBracket> TaxBrackets { get; set; }
    }
}
