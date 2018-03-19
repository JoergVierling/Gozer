using System;
using Gozer.Contract.Communication;
using Gozer.Core;

namespace Gozer.Core.Communication
{
    public class ServiceRegistrationAck : IServiceRegistrationAck
    {
        public Guid ServiceID{ get; set; }

        public ServiceRegistrationAck(Guid serviceId)
        {
            ServiceID = serviceId;
        }
    }
}
