using Application.Extension;
using Infrastructure.Extension;

namespace Web.Extension
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAppDI(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddApplicationDI();
            services.AddInfrastructureDI(configuration);

            return services;
        }
    }
}
