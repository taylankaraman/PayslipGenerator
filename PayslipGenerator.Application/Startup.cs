using Microsoft.Extensions.DependencyInjection;
using PayslipGenerator.Application.Interfaces;
using PayslipGenerator.Application.Services;
using PayslipGenerator.Persistence;

namespace PayslipGenerator.Application
{
    public static class Startup
    {
        public static IServiceCollection RegisterServices()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddSingleton<IGeneratePayslipService, GeneratePayslipService>();
            serviceCollection.AddSingleton<IDisplayPayslipService, DisplayPayslipService>();
            serviceCollection.AddPersistence();

            return serviceCollection;
        }
    }
}
