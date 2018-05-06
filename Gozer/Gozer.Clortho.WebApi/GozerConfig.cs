using System;
using System.Web.Http;
using Gozer.Clortho.WebApi.FactoryClasses;
using Gozer.Contract;

namespace Gozer.Clortho.WebApi
{
    public static class GozerConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static IClorthoRegister Register(HttpConfiguration config,string server)
        {
            var route = config.Routes.MapHttpRoute(
                "Health",                           // Route name
                "Health/{id}",                      // URL with parameters
                new { controller = "Health", id = RouteParameter.Optional }
            );

            IClorthoRegister registratedServiceIstance = ClorthoFactory.Register(server);

            return registratedServiceIstance;
        }

    }
}
