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
            var context = serviceProvider.GetRequiredService<PayslipGeneratorContext>();

            Bootstrap.AddData(context);

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

            var employee = new Employee
            {
                Name = nameArg,
                AnnualSalary = grossAnnualSalaryArg
            };

            var payslip = generatePayslipService.CreatePayslip(employee, "TaxTable1");
            displayPayslipService.PrintPayslip(payslip);
        }
    }
}
