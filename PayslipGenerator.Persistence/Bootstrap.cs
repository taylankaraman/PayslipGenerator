using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace PayslipGenerator.Persistence
{
    public static class Bootstrap
    {
        public static void AddPersistence(this IServiceCollection services)
        {
            services.AddDbContext<PayslipGeneratorContext>(options =>
                options.UseInMemoryDatabase("ProtoTypeAndTestDB" + Guid.NewGuid()), ServiceLifetime.Singleton);
        }
    }
}
