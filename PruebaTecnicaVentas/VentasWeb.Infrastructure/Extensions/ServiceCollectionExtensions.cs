using Microsoft.Extensions.DependencyInjection;

namespace VentasWeb.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services)
        {
            //services.AddServices();
            return services;
        }

        private static void AddServices(this IServiceCollection services)
        {
            //services
            //    .AddTransient<IEmailService, EmailService>();
        }
    }
}
