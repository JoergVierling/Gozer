using System;
using System.ServiceModel;
using System.Threading.Tasks;
using Gozer.Contract;
using Gozer.Contract.Communication;

namespace Gozer.Clortho.WCF
{
    public interface IClortho
    {
        Task<T> Get<T>();
        Task<T> GetDuplex<T>(InstanceContext callback);
        Task<IServiceDelivery> GetApiInformation<T>();
        Task<bool> HasOne<T>();

        event EventHandler<IConnectionStatusChangedEvent> ConnectionEvent;
    }
}