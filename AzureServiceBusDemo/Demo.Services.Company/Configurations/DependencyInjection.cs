using Demo.Services.CompanyAPI.DbContexts;
using Demo.Services.CompanyAPI.Interfaces;
using Demo.Services.CompanyAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.Services.CompanyAPI.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCompanyDbCotext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CompanyDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure();
                    });
            });

            return services;
        }

        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<ICompanyService, CompanyService>();

            return services;
        }
    }
}
