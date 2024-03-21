using Microsoft.Extensions.DependencyInjection;

namespace MiddlewarePOC.Middlewares
{
    public static class ServiceRegistration
    {

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<ResponseTimeMiddleware>();
            return services;
        }
    }
}
