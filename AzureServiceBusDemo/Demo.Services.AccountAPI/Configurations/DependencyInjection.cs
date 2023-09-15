using Demo.Services.AccountAPI.DbContexts;
using Demo.Services.AccountAPI.Interfaces;
using Demo.Services.AccountAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace Demo.Services.AccountAPI.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCompanyDbCotext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AccountDbContext>(options =>
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
            services.AddScoped<IAccountService, AccountService>();

            return services;
        }
    }
}

