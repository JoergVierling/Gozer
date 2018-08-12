using System.ServiceModel;

namespace Gozer.Contract.Health
{
    [ServiceContract]
    public interface IServicesHealthConnection
    {
        [OperationContract]
        bool IsAlive();
    }
}