using System;
using Newtonsoft.Json;
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

            string[] arguments = Environment.GetCommandLineArgs();

            var taxTableJson = loadTaxTableService.ReadTaxTable();
            TaxTable taxTable = JsonConvert.DeserializeObject<TaxTable>(taxTableJson);

            Employee employee = new Employee
            {
                Name = arguments[1],
                AnnualSalary = Convert.ToDecimal(arguments[2])
            };

            var payslip = generatePayslipService.CreatePayslip(employee, taxTable);
            displayPayslipService.PrintPayslip(payslip);
        }
    }
}
