using System.IO;
using System.Net;
using System.Threading.Tasks;
using Gozer.Contract;
using Gozer.Contract.Communication;
using Gozer.Core;
using Gozer.Core.Communication;
using Gozer.Endpoints.Manager;
using Gozer.Endpoints.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Gozer.Endpoints.Service
{
    internal class RegisterEndpoint : IEndpointHandler
    {

        private readonly ILogger _logger;
        private readonly IServiceSheldManager _serviceSheldManager;

        public RegisterEndpoint(
            ILogger<RegisterEndpoint> logger, IServiceSheldManager serviceSheldManager)
        {
            _logger = logger;
            _serviceSheldManager = serviceSheldManager;
        }

        public IEndpointManager Process(HttpContext context)
        {
            if (!HttpMethods.IsPost(context.Request.Method))
            {
                _logger.LogWarning("Invalid HTTP method for userinfo endpoint.");
                return new StatusCodeResult(HttpStatusCode.MethodNotAllowed);
            }

            StreamReader reader = new StreamReader(context.Request.Body);
            string requestFromPost = reader.ReadToEnd();

            var jsonSerializerSettings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All
            };

            IServiceDelivery serviceRegister = JsonConvert.DeserializeObject<IServiceDelivery>(requestFromPost, jsonSerializerSettings);

            if (serviceRegister != null)
            {
                var guid = _serviceSheldManager.AddService(serviceRegister);

                IServiceRegistrationAck ack = new ServiceRegistrationAck(guid);

                return new ServiceResultManager<IServiceRegistrationAck>(ack);
            }

            return new StatusCodeResult(401);
        }

       
    }
}
