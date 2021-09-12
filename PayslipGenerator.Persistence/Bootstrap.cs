using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PayslipGenerator.Domain.Models;
using PayslipGenerator.Persistence.Interfaces;
using PayslipGenerator.Persistence.Repositories;

namespace PayslipGenerator.Persistence
{
    public static class Bootstrap
    {
        public static void AddPersistence(this IServiceCollection services)
        {
            services.AddDbContext<PayslipGeneratorContext>(options =>
            {
                options.UseInMemoryDatabase("TestDB" + Guid.NewGuid());
            }, ServiceLifetime.Singleton);

            services.AddSingleton<IPayslipGeneratorRepository, PayslipGeneratorRepository>();
        }

        public static void AddData(PayslipGeneratorContext context)
        {
            var taxBracket1 = new TaxBracket
            {
                LowerLimit = 0,
                HigherLimit = 20000,
                TaxRate = 0
            };

            context.TaxBrackets.Add(taxBracket1);

            var taxBracket2 = new TaxBracket
            {
                LowerLimit = 20000,
                HigherLimit = 40000,
                TaxRate = 0.1m
            };

            context.TaxBrackets.Add(taxBracket2);

            var taxBracket3 = new TaxBracket
            {
                LowerLimit = 40000,
                HigherLimit = 80000,
                TaxRate = 0.2m
            };

            context.TaxBrackets.Add(taxBracket3);

            var taxBracket4 = new TaxBracket
            {
                LowerLimit = 80000,
                HigherLimit = 180000,
                TaxRate = 0.3m
            };

            context.TaxBrackets.Add(taxBracket4);

            var taxBracket5 = new TaxBracket
            {
                LowerLimit = 180000,
                HigherLimit = decimal.MaxValue,
                TaxRate = 0.4m
            };

            context.TaxBrackets.Add(taxBracket5);

            var taxTable1 = new TaxTable
            {
                TaxTableName = "TaxTable1",
                TaxBrackets = new List<TaxBracket>
                {
                    taxBracket1,
                    taxBracket2,
                    taxBracket3,
                    taxBracket4,
                    taxBracket5
                }
            };

            context.TaxTables.Add(taxTable1);

            context.SaveChanges();
        }
    }
}
