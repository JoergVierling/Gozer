using System.Net.Http;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Gozer.Core.Communication;
using Newtonsoft.Json;

namespace Gozer.Core.Wong.FactoryClasses
{
    public class Consume
    {
        private readonly Wong _wong;

        public Consume(Wong server)
        {
            _wong = server;
        }

        public T Get<T>() 
        {
          var svcManager = new ServiceManager<T>();

            var service = svcManager.GetService(_wong.BasUrl);

            var channel = svcManager.GetChannel(service.binding, service.EndpointAdress);

            return channel;
        }
    }
}