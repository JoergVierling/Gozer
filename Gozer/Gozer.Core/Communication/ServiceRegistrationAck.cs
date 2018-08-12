using System;
using Gozer.Contract.Communication;

namespace Gozer.Core.Communication
{
    public class ServiceRegistrationAck : IServiceRegistrationAck
    {
        public Guid ServiceID { get; set; }
        public bool Succed { get; set; }
        public string Message { get; set; }

        public ServiceRegistrationAck(Guid serviceId)
        {
            ServiceID = serviceId;
            Succed = true;
            Message = "Service Registrated";
        }

        public ServiceRegistrationAck()
        {
        }
    }
}