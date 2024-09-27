using System.Web.Http;
using System.Web.Services.Description;
using MediatR;
using MediatR.Registration;
using Microsoft.Extensions.DependencyInjection;
using Unity;
using Unity.Lifetime;
using Unity.WebApi;
using System.Configuration;
using VentasWeb.Infrastructure.Extensions;
using System.Collections.Generic;
using Microsoft.Ajax.Utilities;
using System.Reflection;
using Unity.Injection;
using VentasWeb.Application.Features.Clientes.Queries.GetAllClients;
using System;
using System.Web.Http.Controllers;

namespace VentasWeb.WebAPI
{
    public static class WebApiConfig
    {
        public class VentasWebServiceProvider : IServiceProvider
        {
            private readonly ServicesContainer _servicesContainer;
            public VentasWebServiceProvider(ServicesContainer servicesContainer) => _servicesContainer = servicesContainer;
            public object GetService(Type serviceType)
            {
                return _servicesContainer.GetService(serviceType);
            }
        }
        public static void Register(HttpConfiguration config)
        {
            // Configurar Inyección de Dependencias
            var container = new UnityContainer();

            // Aquí registras las dependencias (interfaz -> implementación)
            // Ejemplo: container.RegisterType<IMiServicio, MiServicio>(new HierarchicalLifetimeManager());

            config.DependencyResolver = new UnityDependencyResolver(container);
            config.AddInfrastructureLayer(container, GetConnectionStrings());
            var mediator = new MediatR.Mediator(new VentasWebServiceProvider(config.Services));
            container.RegisterType<IRequestHandler<GetAllClientsQuery, List<GetAllClientsDTO>>, GetAllClientsQueryHandler>(new HierarchicalLifetimeManager());
            container.RegisterInstance<IMediator>(mediator);


            // Configuración y servicios de Web API


            // Rutas de Web API
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
        public static Dictionary<string, string> GetConnectionStrings()
        {
            var connectionsDictionary = new Dictionary<string, string>();
            for (var i = 0; i < ConfigurationManager.ConnectionStrings.Count; i++)
            {
                connectionsDictionary.Add(ConfigurationManager.ConnectionStrings[i].Name, ConfigurationManager.ConnectionStrings[i].ConnectionString);
            }
            return connectionsDictionary;
        }
    }
}
