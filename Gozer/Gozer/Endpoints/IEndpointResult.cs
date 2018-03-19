using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Gozer.Endpoints
{
    public interface IEndpointManager
    {
        /// <summary>
        /// Executes the result.
        /// </summary>
        /// <param name="context">The HTTP context.</param>
        /// <returns></returns>
        Task ExecuteAsync(HttpContext context);
    }
}