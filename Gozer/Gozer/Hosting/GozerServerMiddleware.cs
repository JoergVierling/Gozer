using System;
using System.Net;
using System.Threading.Tasks;
using Gozer.Contract;
using Gozer.Endpoints;
using Gozer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Gozer.Hosting
{
    public class GozerServerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="GozerServerMiddleware"/> class.
        /// </summary>
        /// <param name="next">The next.</param>
        /// <param name="logger">The logger.</param>
        public GozerServerMiddleware(RequestDelegate next, ILogger<GozerServerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context, IEndpointRouter router)
        {
            var endpoint = router.Find(context);

            if (endpoint != null)
            {
                _logger.LogInformation("Invoking GozerServer endpoint: {endpointType} for {url}",
                    endpoint.GetType().FullName, context.Request.Path.ToString());


                IEndpointManager result = endpoint.Process(context);

                if (result != null)
                {
                    _logger.LogTrace("Invoking result: {type}", result.GetType().FullName);
                    await result.ExecuteAsync(context);
                }

                return;
            }



            await _next(context);
        }
    }
}
