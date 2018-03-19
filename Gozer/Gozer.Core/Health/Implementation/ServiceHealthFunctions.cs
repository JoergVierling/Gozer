using System;
using Gozer.Contract;
using Gozer.Core.Health.Contract;

namespace Gozer.Core.Health.Implementation
{
    public class ServiceHealthFunctions
    {
        private readonly IServicesHealthConnection _channel;

        public ServiceHealthFunctions(ServicesBinding binding, string endpoint)
        {
            var svc = new ServiceManager<IServicesHealthConnection>();
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
                //_logger.LogInformation($"Service Died {serviceObject.EndpointAdress}");
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
                //_logger.LogInformation($"Service {serviceObject.EndpointAdress} Died with Message:{e.Message}");
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
                //_logger.LogInformation($"Service {serviceObject.EndpointAdress} Died with Message:{e.Message}");

            }

            return memUsage;
        }

    }
}
