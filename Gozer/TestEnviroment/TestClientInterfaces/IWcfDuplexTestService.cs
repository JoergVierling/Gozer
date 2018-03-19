using System.ServiceModel;
using Gozer.Core;
using Gozer.Core.Health.Contract;

namespace TestClientInterfaces
{
[ServiceContract(CallbackContract = typeof(IWcfDuplexTestCallback))]
    public interface IWcfDuplexTestService : IServicesHealthConnection
    {
        [OperationContract]
        string GetMeldung();
    }
}
