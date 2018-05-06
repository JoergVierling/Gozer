using System.Collections.Generic;
using System.Web.Http;

namespace ControllerTest.Controllers
{
    public class HealthController : ApiController
    {
        // GET api/values
        public IHttpActionResult Get()
        {
            var value = new string[] {"value1", "value2"};
            return Json(value);
        }






    }
}
