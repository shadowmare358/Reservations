using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace TestApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{name}/{city}",
                defaults: new { name = RouteParameter.Optional, city = RouteParameter.Optional }
            );
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling
            = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        }
    }
}
