using Microsoft.EntityFrameworkCore;

namespace SMSProviders.API.Context
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDatabaseContext(
        this IServiceCollection services,
        ConfigurationManager configuration)
        {
            var st = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseMySql(st, ServerVersion.AutoDetect(st));
            });

            return services;
        }
    }
}
