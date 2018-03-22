using System;
using System.Net.Http;
using Gozer.Contract;
using Gozer.Contract.Communication;
using Gozer.Core;
using Newtonsoft.Json;

namespace Gozer.Clortho
{
    public class RegistratedServiceIstance : IRegistratedServiceIstance
    {
        public IGozerServer GozerServer { get; set; }
        private readonly IServiceRegistrationAck _ack;

        public RegistratedServiceIstance(IGozerServer gozerServer, IServiceRegistrationAck ack)
        {
            GozerServer = gozerServer;
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

            var path = GozerServer.BasUrl + ProtocolRoutePaths.Remove; ;

            var response = client.PostAsync(path, new StringContent(data)).Result;

            response.EnsureSuccessStatusCode();
        }
    }
}
