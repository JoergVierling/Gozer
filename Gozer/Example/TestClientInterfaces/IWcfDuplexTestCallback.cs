using System.ServiceModel;
using Gozer.Core;
using Gozer.Core.Health.Contract;

namespace TestClientInterfaces
{
    [ServiceContract]
    public interface IWcfDuplexTestCallback
    {
        [OperationContract(IsOneWay = true)]
        void ReturnRuntime(string userName);
    }
}
