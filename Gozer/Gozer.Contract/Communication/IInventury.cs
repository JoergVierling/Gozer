using System.Collections.Generic;
using Gozer.Contract.Health;

namespace Gozer.Contract.Communication
{
    public interface IInventury
    {
        List<IServiceHealth> services { get; set; }
    }
}