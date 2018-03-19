using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Gozer.Endpoints;
using Microsoft.AspNetCore.Http;

namespace Gozer.Endpoints.Results
{
    /// <summary>
    /// Result for a raw HTTP status code
    /// </summary>
    /// <seealso cref="IEndpointResult" />
    public class StatusCodeResult : IEndpointManager
    {
        /// <summary>
        /// Gets the status code.
        /// </summary>
        /// <value>
        /// The status code.
        /// </value>
        public int StatusCode { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="StatusCodeResult"/> class.
        /// </summary>
        /// <param name="statusCode">The status code.</param>
        public StatusCodeResult(HttpStatusCode statusCode)
        {
            StatusCode = (int)statusCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StatusCodeResult"/> class.
        /// </summary>
        /// <param name="statusCode">The status code.</param>
        public StatusCodeResult(int statusCode)
        {
            StatusCode = statusCode;
        }

        /// <summary>
        /// Executes the result.
        /// </summary>
        /// <param name="context">The HTTP context.</param>
        /// <returns></returns>
        public Task ExecuteAsync(HttpContext context)
        {
            context.Response.StatusCode = StatusCode;

            return Task.CompletedTask;
        }
    }
}