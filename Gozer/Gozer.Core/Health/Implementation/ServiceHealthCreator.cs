using Gozer.Contract;
using Gozer.Core.Health.Model;


namespace Gozer.Core.Health.Implementation
{
    //Manager

    public class ServiceHealthCreator
    {
        private readonly ServiceHealthFunctions _srcFunctions;

        public ServiceHealthCreator(ServiceHealthFunctions serviceHealthFunctions)
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

