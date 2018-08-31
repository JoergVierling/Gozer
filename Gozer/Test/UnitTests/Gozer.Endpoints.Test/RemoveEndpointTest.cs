using System;
using System.IO;
using FluentAssertions;
using Gozer.CommonTest;
using Gozer.Core.Communication;
using Gozer.Endpoints.Results;
using Gozer.Endpoints.Service;
using IdentityServer4.UnitTests.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Gozer.Endpoints.Test
{
    [TestClass]
    public class RemoveEndpointTest
    {
        private HttpContext _context;
        private RemoveEndpoint _subject;

        private ILogger<RemoveEndpoint> _fakeLogger = TestLogger.Create<RemoveEndpoint>();

        private readonly string _removeEnpoint = "/Service/Remove";

        public RemoveEndpointTest()
        {
            _context = new MockHttpContextAccessor().HttpContext;
            _subject = new RemoveEndpoint(_fakeLogger, new MockServiceSheldManager());
        }


        [TestMethod]
        public void Call()
        {
            var jsonSerializerSettings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All
            };

            var serviceRequest = new ServiceRegistrationAck
            {
                ServiceID = Guid.Parse("fe4947d7-0293-4b93-8b74-2344536b81a0")
            };

            string data = JsonConvert.SerializeObject(serviceRequest, jsonSerializerSettings);

            _context.Request.Method = "Post";
            _context.Request.Path = new PathString(_removeEnpoint);
            _context.Request.Body = ToStream(data);

            StatusCodeResult result = _subject.Process(_context) as StatusCodeResult;

            result.Should().NotBeNull();
            result.StatusCode.Should().Be(StatusCodes.Status202Accepted);
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