using Demo.Services.CompanyAPI.DbContexts;
using Microsoft.EntityFrameworkCore;
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

        //public static IServiceCollection AddDomainServices(this IServiceCollection services)
        //{
        //    // TODO: Register services here
        //    throw new NotImplementedException();
        //}
    }
}
