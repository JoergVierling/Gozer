using System.Collections.Generic;
using Gozer.Core.Health.Model;

namespace Gozer.Contract.Communication
{
    public interface IInventury
    {
        List<IServiceHealth> services { get; set; }
    }
}
