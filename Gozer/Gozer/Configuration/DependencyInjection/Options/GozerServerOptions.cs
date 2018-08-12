
using Gozer.Options;

namespace Gozer.Configuration.DependencyInjection.Options
{
    public class GozerServerOptions
    {
        public Secrutiy Secrutiy { get; set; } = new Secrutiy();
        public ServiceHolding ServiceHolding { get; set; } = new ServiceHolding();
    }
}
