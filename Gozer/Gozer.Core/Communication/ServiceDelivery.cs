using Gozer.Contract;
using Gozer.Contract.Communication;
using Gozer.Core;

namespace Gozer.Core.Communication
{
    public class ServiceDelivery : IServiceDelivery
    {
        public string AssambliQualifiedName { get; set; }
        public ServicesBinding binding { get; set; }
        public string EndpointAdress { get; set; }
        public byte[] Signature { get; set; }
    }
}
