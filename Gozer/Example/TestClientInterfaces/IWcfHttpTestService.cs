using System.ServiceModel;
using Gozer.Core;
using Gozer.Core.Health.Contract;

namespace TestClientInterfaces
{
    [ServiceContract]
    public interface IWcfHttpTestService : IServicesHealthConnection
    {
        [OperationContract]
        string GetMeldung();
    }
}
