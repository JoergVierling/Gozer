using System;
using System.Net.Http;
using Gozer.Contract.Communication;
using Gozer.Core.Communication;
using Newtonsoft.Json;

namespace Gozer.Core.Wong
{
    public class RegistratedServiceIstance : IDisposable
    {
        private readonly Wong _wong;
        private readonly IServiceRegistrationAck _ack;

        public RegistratedServiceIstance(Wong wong, IServiceRegistrationAck ack)
        {
            _wong = wong;
            _ack = ack;
        }

        public void Dispose()
        {
            HttpClient client = new HttpClient();

            var jsonSerializerSettings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All
            };

            string data = JsonConvert.SerializeObject(_ack, jsonSerializerSettings);

            var path = _wong.BasUrl + ProtocolRoutePaths.Remove; ;

            var response = client.PostAsync(path, new StringContent(data)).Result;

            response.EnsureSuccessStatusCode();

        }
    }
}
