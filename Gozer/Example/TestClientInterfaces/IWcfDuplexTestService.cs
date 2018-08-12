using System.ServiceModel;
using Gozer.Contract.Health;
using Gozer.Core;

namespace TestClientInterfaces
{
    [ServiceContract(CallbackContract = typeof(IWcfDuplexTestCallback))]
    public interface IWcfDuplexTestService : IServicesHealthConnection
    {
        [OperationContract]
        string GetMeldung();
    }
}