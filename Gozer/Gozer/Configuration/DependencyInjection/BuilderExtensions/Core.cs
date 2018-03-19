// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using Gozer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Gozer.Configuration;
using Gozer.Contract;
using Gozer.Endpoints;
using Gozer.Endpoints.Service;
using Gozer.Hosting;

using Gozer.Core;
using Gozer.Options;
using Gozer.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Builder extension methods for registering core services
    /// </summary>
    public static class BuilderExtensionsCore
    {
        /// <summary>
        /// Adds the required platform services.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns></returns>
        public static IGozerServerBuilder AddRequiredPlatformServices(this IGozerServerBuilder builder)
        {
            builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddOptions();
            builder.Services.AddSingleton(resolver => resolver.GetRequiredService<IOptions<GozerServerOptions>>().Value);
            builder.Services.AddSingleton<IServiceSheldManager, ServiceSheldManager>();

            return builder;
        }

        public static IGozerServerBuilder AddDefaultEndpoints(this IGozerServerBuilder builder)
        {
            builder.Services.AddTransient<IEndpointRouter, EndpointRouter>();
            builder.AddEndpoint<RegisterEndpoint>(EndpointNames.Register, ProtocolRoutePaths.Register);
            builder.AddEndpoint<RemoveEndpoint>(EndpointNames.Remove, ProtocolRoutePaths.Remove);
            builder.AddEndpoint<RequestEndpoint>(EndpointNames.Request, ProtocolRoutePaths.Request);
            builder.AddEndpoint<HealthEndpoint>(EndpointNames.Health, ProtocolRoutePaths.Health);

            return builder;
        }

        public static IGozerServerBuilder AddEndpoint<T>(this IGozerServerBuilder builder, string name, PathString path)
            where T : class, IEndpointHandler
        {
            builder.Services.AddTransient<T>();
            builder.Services.AddSingleton(new Endpoint(name, path, typeof(T)));

            return builder;
        }
    }
}