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
    public class ClorthoRegister : IClorthoRegister
    {
        private readonly GozerServer _gozerServer;

        public event EventHandler<IConnectionStatusChangedEvent> ConnectionEvent;

        public ClorthoRegister(GozerServer server)
        {
            _gozerServer = server;
        }

        public async Task<IRegistratedServiceIstance> AddService<T>(string endpoint, ServicesBinding binding) where T : IServicesHealthConnection
        {
            HttpClient client = new HttpClient();

            var jsonSerializerSettings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All
            };

            var serviceRequest = new ServiceDelivery()
            {
                AssambliQualifiedName = typeof(T).AssemblyQualifiedName,
                EndpointAdress = endpoint,
                binding = binding
            };

            string data = JsonConvert.SerializeObject(serviceRequest, jsonSerializerSettings);

            var path = _gozerServer.BasUrl + ProtocolRoutePaths.Register;

            HttpResponseMessage response = null;

            do
            {
                try
                {
                    response = await client.PostAsync(path, new StringContent(data));

                    ConnectionEvent?.Invoke(this, new ConnectionStatusChangedEvent(isConnected: true));
                }
                catch (Exception e)
                {
                    ConnectionEvent?.Invoke(this, new ConnectionStatusChangedEvent(exception: e));
                }



            } while (response?.StatusCode != HttpStatusCode.OK);

            string content = await response.Content.ReadAsStringAsync();

            IServiceRegistrationAck ack =
                JsonConvert.DeserializeObject<IServiceRegistrationAck>(content, jsonSerializerSettings);

            IRegistratedServiceIstance registeredService = new RegistratedServiceIstance(_gozerServer, ack);

            return registeredService;
        }
    }


}