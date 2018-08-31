using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Gozer.CommonTest;
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
    public class HealthEndpointTest
    {
        private HttpContext _context;
        private HealthEndpoint _subject;

        private ILogger<HealthEndpoint> _fakeLogger = TestLogger.Create<HealthEndpoint>();

        private readonly string _healthEnpoint = "/Service/Health";

        public HealthEndpointTest()
        {
            _context = new MockHttpContextAccessor().HttpContext;
            _subject = new HealthEndpoint(_fakeLogger, new MockServiceSheldManager());
        }

        [TestMethod]
        public async Task Call()
        {
            _context.Request.Method = "GET";
            _context.Request.Path = new PathString(_healthEnpoint);

            var result = _subject.Process(_context) as ServiceResultManager<IInventury>;

            result.Should().NotBeNull();
            result._result.services.Should().HaveCount(1);

            await result.ExecuteAsync(_context);

            _context.Response.Body.Seek(0, SeekOrigin.Begin);
            using (var rdr = new StreamReader(_context.Response.Body))
            {
                var context = rdr.ReadToEnd();

                var jsonSerializerSettings = new JsonSerializerSettings()
                {
                    TypeNameHandling = TypeNameHandling.All
                };
                
                var service = JsonConvert.DeserializeObject<IInventury>(context,jsonSerializerSettings);

                service.services.Should().HaveCount(1);
                service.services.First().IsAlive.Should().BeTrue();
                service.services.First().EndpointAdress.Should().Be("localHostAddress");
                service.services.First().AssambliQualifiedName.Should().Be("MockAssambliQualifiedName");
            }
        }
    }
}