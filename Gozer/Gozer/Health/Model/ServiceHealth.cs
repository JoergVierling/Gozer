using System;
using Gozer.Contract;
using Gozer.Core.Health.Model;

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
            binding = delivery.Binding;
            EndpointAdress = delivery.EndpointAdress;
            LastCall = delivery.LastCall;
        }

        public string AssambliQualifiedName { get; set; }
        public ServicesBinding binding { get; set; }
        public string EndpointAdress { get; set; }

        public bool IsAlive { get; set; }
        public DateTime LastCall { get; set; }
        public string CpuUsage { get; set; }
        public string FreeMemory { get; set; }
        public byte[] Signature { get; set; }
    }
}
