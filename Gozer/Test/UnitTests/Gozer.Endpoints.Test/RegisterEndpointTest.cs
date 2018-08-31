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
    public class RegisterEndpointTest
    {
        private HttpContext _context;
        private RegisterEndpoint _subject;

        private ILogger<RegisterEndpoint> _fakeLogger = TestLogger.Create<RegisterEndpoint>();

        private readonly string _registerEnpoint = "/Service/Register";

        public RegisterEndpointTest()
        {
            _context = new MockHttpContextAccessor().HttpContext;
            _subject = new RegisterEndpoint(_fakeLogger, new MockServiceSheldManager(), new MockAuthorizeManager());
        }


        [TestMethod]
        public async Task Call()
        {
            var jsonSerializerSettings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All
            };

            var serviceRequest = new ServiceDelivery()
            {
                AssambliQualifiedName = "TestMethod",
                EndpointAdress = "testEndpoint",
                Binding = ServicesBinding.WebApi
            };

            string data = JsonConvert.SerializeObject(serviceRequest, jsonSerializerSettings);

            _context.Request.Method = "Post";
            _context.Request.Path = new PathString(_registerEnpoint);
            _context.Request.Body = ToStream(data);

            var result = _subject.Process(_context) as ServiceResultManager<IServiceRegistrationAck>;

            result.Should().NotBeNull();
            
            await result.ExecuteAsync(_context);

            _context.Response.Body.Seek(0, SeekOrigin.Begin);
            using (var rdr = new StreamReader(_context.Response.Body))
            {
                var context = rdr.ReadToEnd();

           var service = JsonConvert.DeserializeObject<IServiceRegistrationAck>(context,jsonSerializerSettings);

                service.Succed.Should().BeTrue();
                service.ServiceID.Should().Be(Guid.Parse("8ee99672-e455-46b1-a5b3-7774eaa80722"));
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