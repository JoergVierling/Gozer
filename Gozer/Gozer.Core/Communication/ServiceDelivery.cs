using Gozer.Contract;
using Gozer.Contract.Communication;

namespace Gozer.Core.Communication
{
    public class ServiceDelivery : IServiceDelivery
    {
        public string AssambliQualifiedName { get; set; }
        public ServicesBinding Binding { get; set; }
        public string EndpointAdress { get; set; }
        public byte[] Signature { get; set; }
    }
}