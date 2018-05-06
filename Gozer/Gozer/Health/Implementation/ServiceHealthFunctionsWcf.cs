using System;
using Gozer.Contract;
using Gozer.Core;
using Gozer.Core.Health.Contract;

namespace Gozer.Health.Implementation
{
    public class ServiceHealthFunctionsWcf : IServiceHealthFunctions
    {
        private readonly IServicesHealthConnection _channel;

        public ServiceHealthFunctionsWcf(ServicesBinding binding, string endpoint)
        {
            var svc = new ServiceManager<IServicesHealthConnection>(0);
            _channel = svc.GetChannel(binding, endpoint);
        }

        public bool IsServiceAlive()
        {

            var isAlive = true;

            try
            {
                isAlive = _channel.IsAlive();
            }
            catch (Exception e)
            {
               
                isAlive = false;
            }

            return isAlive;
        }

        public string GetCpuUsage()
        {
            string cpuLoad = null;

            try
            {
                cpuLoad = _channel.GetCpuLoad();
            }
            catch (Exception e)
            {
                
            }

            return cpuLoad;
        }

        public string GetMemUsage()
        {
            string memUsage = null;

            try
            {
                memUsage = _channel.GetMemLoad();
            }
            catch (Exception e)
            {
   
            }

            return memUsage;
        }

    }
}
