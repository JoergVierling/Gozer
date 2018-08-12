using System.ServiceModel;
using Gozer.Core;

namespace TestClientInterfaces
{
    [ServiceContract]
    public interface IWcfDuplexTestCallback
    {
        [OperationContract(IsOneWay = true)]
        void ReturnRuntime(string userName);
    }
}