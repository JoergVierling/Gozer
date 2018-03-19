using System.Net.Http;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Gozer.Core.Communication;
using Newtonsoft.Json;

namespace Gozer.Core.Clortho.FactoryClasses
{
    public class Consume
    {
        private readonly Clortho _clortho;

        public Consume(Clortho server)
        {
            _clortho = server;
        }

        public T Get<T>() 
        {
          var svcManager = new ServiceManager<T>();

            var service = svcManager.GetService(_clortho.BasUrl);

            var channel = svcManager.GetChannel(service.binding, service.EndpointAdress);

            return channel;
        }

        public T GetDuplex<T>(InstanceContext callback)
        {
            var svcManager = new ServiceManager<T>();

            var service = svcManager.GetService(_clortho.BasUrl);

            var channel = svcManager.GetChannel(service.binding, service.EndpointAdress, callback);

            return channel;
        }
    }
}