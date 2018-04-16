using Microsoft.Extensions.Configuration;
using System;
using Gozer.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class GozerServerServiceCollectionExtensions
    {
        /// <summary>
        /// Creates a builder.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static IGozerServerBuilder AddGozerServerBuilder(this IServiceCollection services)
        {
            return new GozerServerBuilder(services);
        }

        /// <summary>
        /// Adds GozerServer.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static IGozerServerBuilder AddGozerServer(this IServiceCollection services, Action<GozerServerOptions> setupAction)
        {
            services.Configure(setupAction);
            var builder = services.AddGozerServerBuilder();

            builder.AddRequiredPlatformServices().AddDefaultEndpoints();

            return builder;
        }


        public static IGozerServerBuilder AddGozerServer(this IServiceCollection services)
        {
            var builder = services.AddGozerServerBuilder();

            builder.AddRequiredPlatformServices().AddDefaultEndpoints();

            return builder;
        }
    }
}
