using System;
using Gozer.Contract;
using Gozer.Contract.Health;

namespace Gozer.Health.Model
{
    public class ServiceHealth : IServiceHealth
    {
        public ServiceHealth()
        {
        }

        public ServiceHealth(IService delivery)
        {
            AssambliQualifiedName = delivery.AssambliQualifiedName;
            Binding = delivery.Binding;
            EndpointAdress = delivery.EndpointAdress;
            LastCall = delivery.LastCall;
        }

        public string AssambliQualifiedName { get; set; }
        public ServicesBinding Binding { get; set; }
        public string EndpointAdress { get; set; }

        public bool IsAlive { get; set; }
        public DateTime LastCall { get; set; }
        public byte[] Signature { get; set; }
    }
}
