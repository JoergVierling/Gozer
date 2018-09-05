using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Gozer.Endpoints;
using Microsoft.AspNetCore.Http;

namespace Gozer.Endpoints.Results
{
    public class StatusCodeResult : IEndpointManager
    {

        public int StatusCode { get; }

        public StatusCodeResult(HttpStatusCode statusCode)
        {
            StatusCode = (int) statusCode;
        }


        public StatusCodeResult(int statusCode)
        {
            StatusCode = statusCode;
        }

        public Task ExecuteAsync(HttpContext context)
        {
            context.Response.StatusCode = StatusCode;

            return Task.CompletedTask;
        }
    }
}