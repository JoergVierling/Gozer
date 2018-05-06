using System;
using System.Threading.Tasks;
using Gozer.Contract;
using Gozer.Contract.Communication;
using Gozer.Core;

namespace Gozer.Clortho.WebApi.Core.FactoryClasses
{
    public class Clortho : IClortho
    {
        private readonly GozerServer _gozerServer;
        public event EventHandler<IConnectionStatusChangedEvent> ConnectionEvent;
        private readonly int _maxConnectionTime;

        public Clortho(GozerServer server, int maxConnectionTime)
        {
            _gozerServer = server;
            _maxConnectionTime = maxConnectionTime;
        }

        public async Task<IServiceDelivery> GetApiInformation<T>()
        {
            var svcManager = new ServiceManager<T>(ConnectionEvent, _maxConnectionTime);

            IServiceDelivery serivDelivery = null;

            var service = await svcManager.GetService(_gozerServer.BasUrl);

            if (service.Found)
            {
                serivDelivery = service.ServiceInformation;
            }

            return serivDelivery;
        }

        public async Task<bool> HasOne<T>()
        {
            var svcManager = new ServiceManager<T>(ConnectionEvent, _maxConnectionTime);

            var service = await svcManager.GetService(_gozerServer.BasUrl);

            return service.Found;
        }
    }
}