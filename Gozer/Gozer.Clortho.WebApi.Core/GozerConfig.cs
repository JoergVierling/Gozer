using System.Web.Http;

namespace Gozer.Clortho.WebApi.Core
{
    public static class GozerConfig
    {
        //public bool IsAlive { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        //public DateTime LastCall { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        //public string CpuUsage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        //public string FreeMemory { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        //public string AssambliQualifiedName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        //public ServicesBinding binding { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        //public string EndpointAdress { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
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