using Microsoft.Extensions.DependencyInjection;
using PayslipGenerator.Application.Interfaces;
using PayslipGenerator.Application.Services;

namespace PayslipGenerator.Application
{
    public static class Startup
    {
        public static IServiceCollection RegisterServices()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddSingleton<IGeneratePayslipService, GeneratePayslipService>();
            serviceCollection.AddSingleton<IDisplayPayslipService, DisplayPayslipService>();
            serviceCollection.AddSingleton<ILoadTaxTableService, LoadTaxTableService>();

            return serviceCollection;
        }
    }
}
