using System.Net.Http;
using Gozer.Contract;
using Gozer.Contract.Communication;
using Gozer.Core.Communication;
using Gozer.Core.Health.Contract;
using Newtonsoft.Json;

namespace Gozer.Core.Wong.FactoryClasses
{
    public class Register
    {
        private readonly Wong _wong;

        public Register(Wong server)
        {
            _wong = server;
        }

        public RegistratedServiceIstance AddService<T>(string endpoint, ServicesBinding binding) where T : IServicesHealthConnection
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

            var path = _wong.BasUrl + ProtocolRoutePaths.Register;

            var response = client.PostAsync(path, new StringContent(data)).Result;
            response.EnsureSuccessStatusCode();

            string content = response.Content.ReadAsStringAsync().Result;

            IServiceRegistrationAck ack =
                JsonConvert.DeserializeObject<IServiceRegistrationAck>(content, jsonSerializerSettings);

            var registeredService = new RegistratedServiceIstance(_wong, ack);

            return registeredService;
        }
    }
}
