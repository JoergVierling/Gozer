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
    public static class BuilderExtensionsAddCustomShelter
    {
        /// <summary>
        /// Adds custom Shelter
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns></returns>
        public static IGozerServerBuilder AddCustomShelter(this IGozerServerBuilder builder, ISheldService sheldService)
        {
            builder.Services.TryAddSingleton(sheldService);
            builder.Services.TryAddTransient(typeof(IServiceSheldManager), typeof(ServiceSheldManager));

            return builder;
        }

        public static IGozerServerBuilder AddCustomShelter(this IGozerServerBuilder builder, ISheldService sheldService,
            IServiceSelector serviceSelector)
        {
            builder.Services.TryAddSingleton(sheldService);
            builder.Services.AddSingleton(serviceSelector);

            builder.Services.TryAddTransient(typeof(IServiceSheldManager), typeof(ServiceSheldManager));

            return builder;
        }
    }
}