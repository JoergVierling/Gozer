using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using Gozer.Contract;
using Gozer.Core;
using Gozer.Core.Wong;
using TestClientInterfaces;

namespace WcfHttpTestService1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Factory.GetServiceRegistrator("http://localhost:25723")
                .AddService<IWcfHttpTestService>("http://localhost:8081/Service", ServicesBinding.WebHttpBinding))
            {
                ServiceHost host = new ServiceHost(typeof(Service));
                host.Open();
                Console.WriteLine("Service Hosted 1 running");
                Console.Read();
            }
        }
    }
}
