
using Gozer.Contract;

namespace Gozer.Contract.Communication
{
    public interface IServiceDelivery
    {
        string AssambliQualifiedName { get; set; }
        ServicesBinding binding { get; set; }
        string EndpointAdress { get; set; }
    }
}