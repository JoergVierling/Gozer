using System.ServiceModel;
using Gozer.Contract.Health;
using Gozer.Core;

namespace TestClientInterfaces
{
    [ServiceContract]
    public interface IWcfHttpTestService : IServicesHealthConnection
    {
        [OperationContract]
        string GetMeldung();
    }
}
