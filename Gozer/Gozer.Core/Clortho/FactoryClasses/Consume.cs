using System.Net.Http;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Gozer.Core.Communication;
using Newtonsoft.Json;

namespace Gozer.Core.Clortho.FactoryClasses
{
    public class Consume
    {
        private readonly Clortho _Clortho;

        public Consume(Clortho server)
        {
            _Clortho = server;
        }

        public T Get<T>() 
        {
          var svcManager = new ServiceManager<T>();

            var service = svcManager.GetService(_Clortho.BasUrl);

            var channel = svcManager.GetChannel(service.binding, service.EndpointAdress);

            return channel;
        }
    }
}