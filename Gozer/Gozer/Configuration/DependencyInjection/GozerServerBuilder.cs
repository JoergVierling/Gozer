using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Gozer.Configuration
{
    public class GozerServerBuilder : IGozerServerBuilder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GozerServerBuilder"/> class.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <exception cref="System.ArgumentNullException">services</exception>
        public GozerServerBuilder(IServiceCollection services)
        {
            Services = services ?? throw new ArgumentNullException(nameof(services));
        }

        public IServiceCollection Services { get; }
    }
}
