using System;
using System.IO;
using System.Threading.Tasks;
using FluentAssertions;
using Gozer.CommonTest;
using Gozer.Contract;
using Gozer.Contract.Communication;
using Gozer.Core.Communication;
using Gozer.Endpoints.Manager;
using Gozer.Endpoints.Service;
using IdentityServer4.UnitTests.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Gozer.Endpoints.Test
{
    [TestClass]
    public class RequestEndpointTest
    {
        private HttpContext _context;
        private RequestEndpoint _subject;

        private ILogger<RequestEndpoint> _fakeLogger = TestLogger.Create<RequestEndpoint>();

        private readonly string _requestEnpoint = "/Service/Request";

        public RequestEndpointTest()
        {
            _context = new MockHttpContextAccessor().HttpContext;
            _subject = new RequestEndpoint(_fakeLogger, new MockServiceSheldManager());
        }


        [TestMethod]
        public async Task Call()
        {
            var jsonSerializerSettings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All
            };

            var serviceRequest = new ServiceRequest("MockAssambliQualifiedName");

            string data = JsonConvert.SerializeObject(serviceRequest, jsonSerializerSettings);

            _context.Request.Method = "Post";
            _context.Request.Path = new PathString(_requestEnpoint);
            _context.Request.Body = ToStream(data);

            var result = _subject.Process(_context) as ServiceResultManager<IServiceDelivery>;

            result.Should().NotBeNull();

            await result.ExecuteAsync(_context);

            _context.Response.Body.Seek(0, SeekOrigin.Begin);
            using (var rdr = new StreamReader(_context.Response.Body))
            {
                var context = rdr.ReadToEnd();
                var service = JsonConvert.DeserializeObject<IServiceDelivery>(context, jsonSerializerSettings);

                service.AssambliQualifiedName.Should().Be("MockAssambliQualifiedName");
                service.Binding.Should().Be(ServicesBinding.WebApi);
                service.EndpointAdress.Should().Be("localHostAddress");
            }
        }

        public static Stream ToStream(string str)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(str);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }
}