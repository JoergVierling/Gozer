using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
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
    internal class RemoveEndpoint : IEndpointHandler
    {

        private readonly ILogger _logger;
        private readonly IServiceSheldManager _serviceSheldManager;

        public RemoveEndpoint(
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

            IServiceRegistrationAck serviceDelivery = JsonConvert.DeserializeObject<IServiceRegistrationAck>(requestFromPost, jsonSerializerSettings);

            HttpStatusCode httpStatus = HttpStatusCode.NotFound;

            if (serviceDelivery?.ServiceID != null)
            {
                _serviceSheldManager.Remove(serviceDelivery.ServiceID);

                httpStatus = HttpStatusCode.Accepted;
            }

            return new StatusCodeResult(httpStatus);
        }
    }
}
