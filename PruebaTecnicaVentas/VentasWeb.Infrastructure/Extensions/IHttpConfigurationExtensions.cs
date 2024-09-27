using System.Web.Http;
using Unity;
using Unity.Lifetime;
using VentasWeb.Application.Services;
using VentasWeb.Application.Extensions;
using VentasWeb.Infrastructure.Services;
using System.Collections.Generic;
using VentasWeb.Persistence.Contexts;
using VentasWeb.Persistence.Extensions;

namespace VentasWeb.Infrastructure.Extensions
{
    public static class IHttpConfigurationExtensions
    {

        private static string VENTAS_CONNECTION_STRING = "VentasWebConnectionString";
        public static HttpConfiguration AddInfrastructureLayer(this HttpConfiguration configuration, UnityContainer container, Dictionary<string,string> connectionStrings)
        {
            configuration.AddPersistenceLayer(container);
            configuration.AddApplicationLayer(container);
            configuration.AddInfrastructureServices(container, connectionStrings);
            
            return configuration;
        }

        public static void AddInfrastructureServices(this HttpConfiguration configuration, UnityContainer container, Dictionary<string, string> connectionStrings)
        {
            container.RegisterInstance(new ApplicationDbContext(connectionStrings[VENTAS_CONNECTION_STRING]));
            container.RegisterType<IClientService, ClientService>(new HierarchicalLifetimeManager());
        }
    }
}
