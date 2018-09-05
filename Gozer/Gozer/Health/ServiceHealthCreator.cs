using Gozer.Contract;
using Gozer.Health.Model;

namespace Gozer.Health
{
    public class ServiceHealthCreator
    {
        private readonly IServiceHealthFunctions _srcFunctions;

        public ServiceHealthCreator(IServiceHealthFunctions serviceHealthFunctions)
        {
            _srcFunctions = serviceHealthFunctions;
        }

        public ServiceHealth GetServiceHealth(IService service)
        {
            ServiceHealth health = new ServiceHealth(service)
            {
                IsAlive = _srcFunctions.IsServiceAlive()
            };

            return health;
        }
    }
}

