using System;
using System.Collections.Generic;
using System.Text;
using Gozer.Contract.Communication;
using Gozer.Core.Health.Model;

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
