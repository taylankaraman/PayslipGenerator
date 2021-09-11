using System;
using Microsoft.Extensions.DependencyInjection;
using PayslipGenerator.Application.Interfaces;
using PayslipGenerator.Domain.Models;

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
    }
}
