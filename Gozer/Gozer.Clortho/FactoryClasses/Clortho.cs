using System;
using System.Net;
using System.Net.Http;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;
using Gozer.Contract;
using Gozer.Contract.Communication;
using Gozer.Core;
using Gozer.Core.Communication;
using Gozer.Core.Health.Contract;
using Newtonsoft.Json;

namespace Gozer.Clortho.FactoryClasses
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

        public async Task<T> Get<T>()
        {
            T channel = default(T);

            var svcManager = new ServiceManager<T>(ConnectionEvent, _maxConnectionTime);

            var serviceTuple = await svcManager.GetService(_gozerServer.BasUrl);
            if (serviceTuple.Found)
            {
                IServiceDelivery service = serviceTuple.ServiceInformation;
                channel = svcManager.GetChannel(service.binding, service.EndpointAdress);
            }

            return channel;
        }

        public async Task<T> GetDuplex<T>(InstanceContext callback)
        {
            T channel = default(T);

            var svcManager = new ServiceManager<T>(ConnectionEvent, _maxConnectionTime);

            var serviceTuple = await svcManager.GetService(_gozerServer.BasUrl);

            if (serviceTuple.Found)
            {
                IServiceDelivery service = serviceTuple.ServiceInformation;
                channel = svcManager.GetChannel(service.binding, service.EndpointAdress, callback);
            }

            return channel;
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