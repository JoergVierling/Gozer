using System;
using Gozer.Contract;
using Gozer.Contract.Health;
using Gozer.Core;

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
    }
}
