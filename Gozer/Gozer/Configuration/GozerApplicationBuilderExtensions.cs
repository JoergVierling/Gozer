using System;
using System.Collections.Generic;
using System.Text;
using Gozer.Contract;
using Gozer.Hosting;

namespace Microsoft.AspNetCore.Builder
{
    public static class GozerApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseGozerServer(this IApplicationBuilder app)
        {

            app.UseMiddleware<GozerServerMiddleware>();
            app.ExecuteServiceChecker();
            return app;
        }

        internal static void ExecuteServiceChecker(this IApplicationBuilder app)
        {
            IServiceChecker serviceChecker = app.ApplicationServices.GetService(typeof(IServiceChecker)) as IServiceChecker;

            serviceChecker?.Watch();
        }
    }
}
