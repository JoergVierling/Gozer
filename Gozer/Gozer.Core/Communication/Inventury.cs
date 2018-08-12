using System.Collections.Generic;
using Gozer.Contract.Communication;
using Gozer.Contract.Health;

namespace Gozer.Core.Communication
{
    public class Inventury : IInventury
    {
        public List<IServiceHealth> services { get; set; }

        public Inventury(List<IServiceHealth> services)
        {
            this.services = services;
        }
    }
}