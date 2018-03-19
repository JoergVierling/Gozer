using System;
using System.Collections.Generic;
using System.Text;


namespace Microsoft.Extensions.DependencyInjection
{
    public interface IGozerServerBuilder
    {
        IServiceCollection Services { get; }
    }
}
