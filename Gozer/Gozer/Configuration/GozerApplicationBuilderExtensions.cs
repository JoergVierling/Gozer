using System;
using System.Collections.Generic;
using System.Text;
using Gozer.Hosting;

namespace Microsoft.AspNetCore.Builder
{
    public static class GozerApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseGozerServer(this IApplicationBuilder app)
        {

            app.UseMiddleware<GozerServerMiddleware>();

            return app;
        }
    }
}
