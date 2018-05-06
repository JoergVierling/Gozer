using Gozer.Contract;
using Gozer.Health.Model;

namespace Gozer.Health.Implementation
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
                IsAlive = _srcFunctions.IsServiceAlive(),
                CpuUsage = _srcFunctions.GetCpuUsage(),
                FreeMemory = _srcFunctions.GetMemUsage()
            };

            return health;
        }
    }
}

