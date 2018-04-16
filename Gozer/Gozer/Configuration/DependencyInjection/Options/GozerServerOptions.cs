using Gozer.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gozer.Configuration
{
    public class GozerServerOptions
    {
        public Secrutiy Secrutiy { get; set; } = new Secrutiy();
        public ServiceHolding ServiceHolding { get; set; } = new ServiceHolding();
    }
}
