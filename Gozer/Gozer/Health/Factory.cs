using Gozer.Contract;
using Gozer.Core.Health.Model;
using Gozer.Health.Implementation;

namespace Gozer.Health
{
    public class Factory
    {
        public static bool IsServiceAlive(IService src)
        {
            var serviceHealthFuncitons = new ServiceHealthFunctions(src.Binding, src.EndpointAdress);
            return serviceHealthFuncitons.IsServiceAlive();
        }

        public static IServiceHealth GetServiceHealth(IService src)
        {
            var serviceHealthFuncitons = new ServiceHealthFunctions(src.Binding, src.EndpointAdress);

            var srcHealthCreator = new ServiceHealthCreator(serviceHealthFuncitons);

            return srcHealthCreator.GetServiceHealth(src); 
        }
    }
}
