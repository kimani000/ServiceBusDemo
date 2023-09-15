using Demo.Services.ShoppingCartAPI.DbContexts;
using Demo.Services.ShoppingCartAPI.Interfaces;
using Demo.Services.ShoppingCartAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace Demo.Services.ShoppingCartAPI.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCompanyDbCotext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ShoppingCartDbContext>(options =>
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
            services.AddScoped<IShoppingCartService, ShoppingCartService>();

            return services;
        }
    }
}
