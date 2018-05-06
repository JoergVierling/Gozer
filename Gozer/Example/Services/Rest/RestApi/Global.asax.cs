using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Gozer.Clortho;
using Gozer.Clortho.WebApi;
using Gozer.Contract;
using TestClientInterfaces;

namespace RestApi2
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            GlobalConfiguration.Configure(
                configuration => GozerConfig.Register(
                    configuration,
                    "http://localhost:25723").AddService<IRestTestService>("http://localhost:59247/",ServicesBinding.WebApi)
                );
        }
    }
}
