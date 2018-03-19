using System;
using System.Collections.Generic;
using System.Text;
using Gozer.Contract;
using Gozer.Core.Communication;
using Gozer.Core.Health.Implementation;
using Gozer.Core.Health.Model;

namespace Gozer.Core.Health
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
