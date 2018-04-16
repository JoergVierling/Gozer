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
    public static class BuilderExtensionsServiceChecker
    {
        /// <summary>
        /// Adds custom Shelter
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns></returns>
        public static IGozerServerBuilder AddServiceChecker(this IGozerServerBuilder builder)
        {
            builder.Services.TryAddSingleton(typeof(IServiceChecker), typeof(ServiceChecker));
            return builder;
        }
    }
}