using System;
using System.Threading.Tasks;
using Gozer.Contract;
using Gozer.Contract.Communication;

namespace Gozer.Clortho.WebApi.Core
{
    public interface IClortho
    {
        Task<IServiceDelivery> GetApiInformation<T>();
        Task<bool> HasOne<T>();

        event EventHandler<IConnectionStatusChangedEvent> ConnectionEvent;
    }
}