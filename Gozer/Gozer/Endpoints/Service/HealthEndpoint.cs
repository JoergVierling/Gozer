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
    public class HealthEndpoint : IEndpointHandler
    {

        private readonly ILogger _logger;
        private readonly IServiceSheldManager _serviceSheldManager;

        public HealthEndpoint(
            ILogger<HealthEndpoint> logger, IServiceSheldManager serviceSheldManager)
        {
            _logger = logger;
            _serviceSheldManager = serviceSheldManager;
        }

        public IEndpointManager Process(HttpContext context)
        {
            if (!HttpMethods.IsGet(context.Request.Method))
            {
                _logger.LogWarning("Invalid HTTP method for userinfo endpoint.");
                return new StatusCodeResult(HttpStatusCode.MethodNotAllowed);
            }

            var services = _serviceSheldManager.GetInventur();
            var invertury = new Inventury(services);

            return new ServiceResultManager<IInventury>(invertury);
        }

    }
}

