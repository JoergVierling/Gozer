using System;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Gozer.Contract;
using Gozer.Contract.Communication;
using Gozer.Contract.Health;
using Gozer.Core;
using Gozer.Core.Communication;
using Newtonsoft.Json;

namespace Gozer.Clortho.WebApi.FactoryClasses
{
    public class ClorthoRegister : IClorthoRegister
    {
        private readonly IGozerServer _gozerServer;

        public event EventHandler<IConnectionStatusChangedEvent> ConnectionEvent;

        public ClorthoRegister(IGozerServer server)
        {
            _gozerServer = server;
        }

        public async Task<IRegistratedServiceIstance> AddService<T>(string endpoint, ServicesBinding binding) where T : IServicesHealthConnection
        {
            var jsonSerializerSettings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All
            };

            var serviceRequest = new ServiceDelivery()
            {
                AssambliQualifiedName = typeof(T).AssemblyQualifiedName,
                EndpointAdress = endpoint,
                Binding = binding
            };

            string data = JsonConvert.SerializeObject(serviceRequest, jsonSerializerSettings);

            return await Sendregistration<T>(data, jsonSerializerSettings);
        }

        public async Task<IRegistratedServiceIstance> AddService<T>(string endpoint, ServicesBinding binding, X509Certificate2 cert) where T : IServicesHealthConnection
        {
            var jsonSerializerSettings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All
            };

            RSACryptoServiceProvider publicKeyProvider = (RSACryptoServiceProvider)cert.PrivateKey;

            var endpointBytes = Encoding.ASCII.GetBytes(endpoint);
            var encryption = publicKeyProvider.SignData(endpointBytes, new SHA1CryptoServiceProvider());

            var serviceRequest = new ServiceDelivery()
            {
                AssambliQualifiedName = typeof(T).AssemblyQualifiedName,
                EndpointAdress = endpoint,
                Binding = binding,
                Signature = encryption
            };

            string data = JsonConvert.SerializeObject(serviceRequest, jsonSerializerSettings);

            return await Sendregistration<T>(data, jsonSerializerSettings);
        }

        public async Task<IRegistratedServiceIstance> Sendregistration<T>(string data, JsonSerializerSettings jsonSerializerSettings) where T : IServicesHealthConnection
        {

            HttpClient client = new HttpClient();

            var path = _gozerServer.BasUrl + ProtocolRoutePaths.Register;

            HttpResponseMessage response = null;

            do
            {
                try
                {
                    response = await client.PostAsync(path, new StringContent(data));
                }
                catch (Exception e)
                {
                    ConnectionEvent?.Invoke(this, new ConnectionStatusChangedEvent(exception: e));
                }

            } while (response?.StatusCode != HttpStatusCode.OK);

            string content = await response.Content.ReadAsStringAsync();

            IServiceRegistrationAck ack =
                JsonConvert.DeserializeObject<IServiceRegistrationAck>(content, jsonSerializerSettings);

            if (ack.Succed)
            {
                ConnectionEvent?.Invoke(this, new ConnectionStatusChangedEvent(isConnected: true));
            }
            else
            {
                ConnectionEvent?.Invoke(this, new ConnectionStatusChangedEvent(new ConnectionNotAllowedException(ack.Message)));
            }

            IRegistratedServiceIstance registeredService = new RegistratedServiceIstance(_gozerServer, ack);

            return registeredService;
        }
    }


}