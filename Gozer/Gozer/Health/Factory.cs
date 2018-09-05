using System.ComponentModel.Design;
using Gozer.Contract;
using Gozer.Contract.Health;
using Gozer.Health.Implementation;

namespace Gozer.Health
{
    public class Factory
    {
        public static bool IsServiceAlive(IService src)
        {
            IServiceHealthFunctions serviceHealthFuncitons;
            switch (src.Binding)
            {
                case ServicesBinding.WebApi:
                    serviceHealthFuncitons = new ServiceHealthFunctionsWebApi(src.EndpointAdress);
                    break;
                default:
                    serviceHealthFuncitons = new ServiceHealthFunctionsWcf(src.Binding, src.EndpointAdress);
                    break;
            }

            return serviceHealthFuncitons.IsServiceAlive();
        }

        public static IServiceHealth GetServiceHealth(IService src)
        {
            IServiceHealthFunctions serviceHealthFuncitons;
            switch (src.Binding)
            {
                case ServicesBinding.WebApi:
                    serviceHealthFuncitons = new ServiceHealthFunctionsWebApi(src.EndpointAdress);
                    break;
                default:
                    serviceHealthFuncitons = new ServiceHealthFunctionsWcf(src.Binding, src.EndpointAdress);
                    break;
            }

            var srcHealthCreator = new ServiceHealthCreator(serviceHealthFuncitons);

            return srcHealthCreator.GetServiceHealth(src);
        }
    }
}
