using System;
using System.Net.Http;
using Gozer.Contract.Communication;
using Newtonsoft.Json;

namespace Gozer.Core.Clortho
{
    public class RegistratedServiceIstance : IDisposable
    {
        private readonly Clortho _clortho;
        private readonly IServiceRegistrationAck _ack;

        public RegistratedServiceIstance(Clortho clortho, IServiceRegistrationAck ack)
        {
            _clortho = clortho;
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

            var path = _clortho.BasUrl + ProtocolRoutePaths.Remove; ;

            var response = client.PostAsync(path, new StringContent(data)).Result;

            response.EnsureSuccessStatusCode();

        }
    }
}
