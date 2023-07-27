using Demo.Services.OrderAPI.DbContexts;
using Demo.Services.OrderAPI.Interfaces;
using Demo.Services.OrderAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace Demo.Services.OrderAPI.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddOrderDbCotext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OrderDbContext>(options =>
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
            services.AddScoped<IOrderDetailsService, OrderDetailsService>();
            services.AddScoped<IOrderHeaderService, OrderHeaderService>();
            return services;
        }
    }
}
