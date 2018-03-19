using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Gozer.Endpoints
{
    public interface IEndpointHandler
    {
        /// <summary>
        /// Processes the request.
        /// </summary>
        /// <param name="context">The HTTP context.</param>
        /// <returns></returns>
       IEndpointManager Process(HttpContext context);
    }
}