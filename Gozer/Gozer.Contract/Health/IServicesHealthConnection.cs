using System.ServiceModel;

namespace Gozer.Core.Health.Contract
{
    [ServiceContract]
    public interface IServicesHealthConnection
    {
        [OperationContract]
        bool IsAlive();

        [OperationContract]
        string GetCpuLoad();

        [OperationContract]
        string GetMemLoad();
    }
}