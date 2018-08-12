using System.Web.Http;
using Gozer.Contract.Health;
using Gozer.Core.Health.DefaultImplementation;

namespace Gozer.Clortho.WebApi.Core.Controller
{
    public class HealthController : ApiController
    {
        private readonly IHealthClient _healthClient;

        public HealthController(IHealthClient healthClient)
        {
            _healthClient = healthClient;
        }

        public HealthController()
        {
            _healthClient = new HealthClient();
        }

        [Route("IsAlive")]
        public IHttpActionResult IsAlive()
        {
            return Json(_healthClient.IsAlive());
        }
    }
}