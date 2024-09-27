using ExpressMapper;
using MediatR;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Controllers;
using Unity;
using Unity.Lifetime;
using VentasWeb.Application.Features.Clientes.Queries.GetAllClients;
using VentasWeb.Application.Services;
using VentasWeb.Domain.Entities;

namespace VentasWeb.Application.Extensions
{
    public static class IHttpConfigurationExtensions
    {
        public static HttpConfiguration AddApplicationLayer(this HttpConfiguration configuration, UnityContainer container)
        {
            configuration.AddAutoMapper();
            configuration.RegisterMediatr(container);
            configuration.AddValidators();
            
            return configuration;
        }

        private static void AddAutoMapper(this HttpConfiguration configuration)
        {
            Mapper.Register<Cliente, GetAllClientsDTO>();
        }

        private static void RegisterMediatr(this HttpConfiguration configuration, UnityContainer container)
        {
            var assemblies = new[] { Assembly.GetExecutingAssembly() };

            var handlerTypes = assemblies.SelectMany(a => a.GetTypes())
                                         .Where(t => t.GetInterfaces()
                                                       .Any(i => i.IsGenericType &&
                                                                 (i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>) ||
                                                                  i.GetGenericTypeDefinition() == typeof(INotificationHandler<>))))
                                         .ToList();

            foreach (var handlerType in handlerTypes)
            {
                var serviceType = handlerType.GetInterfaces().First(i => i.IsGenericType &&
                    (i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>) ||
                     i.GetGenericTypeDefinition() == typeof(INotificationHandler<>)));

                container.RegisterType(serviceType, handlerType);
            }
        }

        private static void AddValidators(this HttpConfiguration configuration)
        {
            //services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
