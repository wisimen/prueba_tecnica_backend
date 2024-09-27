using System.Web.Http;
using Unity.Lifetime;
using Unity;
using VentasWeb.Application.Repositories;
using VentasWeb.Application.Services;
using VentasWeb.Persistence.Repositories;

namespace VentasWeb.Persistence.Extensions
{
    public static class IHttpConfigurationExtensions
    {
        public static HttpConfiguration AddPersistenceLayer(this HttpConfiguration configuration, UnityContainer container)
        {
            configuration.AddRepositories(container);
            return configuration;
        }

        public static void AddRepositories(this HttpConfiguration configuration, UnityContainer container)
        {
            container.RegisterType(typeof(IUnitOfWork), typeof(UnitOfWork));
            container.RegisterType(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        }
    }
}
