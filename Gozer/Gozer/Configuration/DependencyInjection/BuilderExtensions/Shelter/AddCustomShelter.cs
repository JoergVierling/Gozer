using System.Collections.Generic;
using Gozer.Contract;
using Gozer.Options;
using Gozer.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Builder extension methods for registering in-memory services
    /// </summary>
    public static class BuilderExtensionsInMemory
    {
        /// <summary>
        /// Adds the in memory Shelter.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns></returns>
        public static IGozerServerBuilder AddInMemoryShelter(this IGozerServerBuilder builder)
        {
            builder.Services.TryAddSingleton<ISheldService, InMemoryShelter>();
            builder.Services.TryAddSingleton(typeof(IServiceSheldManager), typeof(ServiceSheldManager));

            return builder;
        }

        public static IGozerServerBuilder AddInMemoryShelter(this IGozerServerBuilder builder,IServiceSelector serviceSelector)
        {
            builder.Services.TryAddSingleton<ISheldService, InMemoryShelter>();
            builder.Services.TryAddSingleton(serviceSelector);

            builder.Services.TryAddSingleton(typeof(IServiceSheldManager), typeof(ServiceSheldManager));

            return builder;
        }
    }
}