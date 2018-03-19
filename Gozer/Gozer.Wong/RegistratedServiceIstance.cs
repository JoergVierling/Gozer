using System;
using System.Net.Http;
using Gozer.Core;
using Gozer.Core;
using Gozer.Core.Communication;
using Newtonsoft.Json;

namespace Gozer.Clortho
{
    public class RegistratedServiceIstance : IDisposable
    {
        private readonly Core.Clortho _Clortho;
        private readonly IServiceRegistrationAck _ack;

        public RegistratedServiceIstance(Core.Clortho Clortho, IServiceRegistrationAck ack)
        {
            _Clortho = Clortho;
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

            var path = _Clortho.BasUrl + ProtocolRoutePaths.Remove; ;

            var response = client.PostAsync(path, new StringContent(data)).Result;

            response.EnsureSuccessStatusCode();

        }
    }
}
