using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Gozer.Configuration;
using Gozer.Contract;
using Gozer.Contract.Communication;
using Gozer.Core;
using Gozer.Core.Communication;
using Gozer.Endpoints.Manager;
using Gozer.Endpoints.Results;
using Gozer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Gozer.Endpoints.Service
{
    internal class RegisterEndpoint : IEndpointHandler
    {

        private readonly ILogger _logger;
        private readonly IServiceSheldManager _serviceSheldManager;
        private readonly IAuthorizeManager _authorizeManager;

        public RegisterEndpoint(
            ILogger<RegisterEndpoint> logger, IServiceSheldManager serviceSheldManager, IAuthorizeManager authorizeManager)
        {
            _logger = logger;
            _serviceSheldManager = serviceSheldManager;
            _authorizeManager = authorizeManager;
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
            IServiceRegistrationAck ack = null;

            if (!_authorizeManager.IsSignitureValid(serviceRegister))
            {
                ack = new ServiceRegistrationAck()
                {
                    Message = "Host is not Signed to provide Services",
                    ServiceID = new System.Guid(),
                    Succed = false
                };

                serviceRegister = null;
            }

            if (!_authorizeManager.IsHostAllowed(serviceRegister))
            {
                ack = new ServiceRegistrationAck()
                {
                    Message = "Host is not Allowed to provide Services",
                    ServiceID = new System.Guid(),
                    Succed = false
                };

                serviceRegister = null;
            }

            if (serviceRegister != null)
            {
                var guid = _serviceSheldManager.AddService(serviceRegister);

                if (guid.HasValue)
                {
                    ack = new ServiceRegistrationAck(guid.Value);
                }
            }
            else
            {
                ack = new ServiceRegistrationAck()
                {
                    Message = "Unexpected Error",
                    ServiceID = new System.Guid(),
                    Succed = false
                };
            }

            return new ServiceResultManager<IServiceRegistrationAck>(ack);
        }
    }

}
