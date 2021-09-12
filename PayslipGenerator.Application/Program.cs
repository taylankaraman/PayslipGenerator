using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using PayslipGenerator.Application.Interfaces;
using PayslipGenerator.Application.Services;
using PayslipGenerator.Domain.Models;
using PayslipGenerator.Persistence;

namespace PayslipGenerator.Application
{
    class Program
    {
        

        static void Main(string[] args)
        {
            var services = Startup.RegisterServices();
            var serviceProvider = services.BuildServiceProvider(true);

            var generatePayslipService = serviceProvider.GetRequiredService<IGeneratePayslipService>();
            var displayPayslipService = serviceProvider.GetRequiredService<IDisplayPayslipService>();
            var loadTaxTableService = serviceProvider.GetRequiredService<ILoadTaxTableService>();
            var context = serviceProvider.GetRequiredService<PayslipGeneratorContext>();

            AddData(context);

            var arguments = Environment.GetCommandLineArgs();

            if (args.Length < 2)
            {
                throw new ArgumentException("Must have two command line arguments");
            }

            var nameArg = arguments[1];
            if (!decimal.TryParse(arguments[2], out var grossAnnualSalaryArg))
            {
                throw new ArgumentException("Invalid input value for salary");
            }

            var taxTable = loadTaxTableService.ReadTaxTable();

            var employee = new Employee
            {
                Name = nameArg,
                AnnualSalary = grossAnnualSalaryArg
            };

            var payslip = generatePayslipService.CreatePayslip(employee, taxTable);
            displayPayslipService.PrintPayslip(payslip);
        }

        private static void AddData(PayslipGeneratorContext context)
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
                TableName = "TaxTable1",
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
