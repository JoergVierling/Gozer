using System.Web.Http;

namespace Gozer.Clortho.WebApi.Core
{
    public static class GozerConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var route = config.Routes.MapHttpRoute(
                "Health", // Route name
                "Health/{id}", // URL with parameters
                new {controller = "Health", id = RouteParameter.Optional}
            );
        }
    }
}