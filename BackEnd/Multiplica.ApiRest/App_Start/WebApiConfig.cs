using Multiplica.ApiRest.App_Start;
using Multiplica.ApiRest.Dependency;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Dispatcher;

namespace Multiplica.ApiRest
{
  public static class WebApiConfig
  {
    public static void Register(HttpConfiguration config)
    {
      // Configuración y servicios de API web
      config.Services.Replace(typeof(IHttpControllerActivator), new WindsorControllerActivator(WindsorConfig.Config()));
      config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
      config.Formatters.JsonFormatter.UseDataContractJsonSerializer = false;

      config.EnableCors(new EnableCorsAttribute("*", "*", "*"));

      // Rutas de API web
      config.MapHttpAttributeRoutes();

      config.Routes.MapHttpRoute(
          name: "DefaultApi",
          routeTemplate: "api/{controller}/{id}",
          defaults: new { id = RouteParameter.Optional }
      );
    }
  }
}
