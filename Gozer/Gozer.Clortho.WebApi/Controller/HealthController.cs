using System.Web.Http;
using Gozer.Contract.Health;
using Gozer.Core.Health.DefaultImplementation;

namespace Gozer.Clortho.WebApi.Controller
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

        [Route("Health/IsAlive")]
        [HttpGet,HttpPost]
        public IHttpActionResult IsAlive()
        {
            return Json(_healthClient.IsAlive());
        }
    }
}
