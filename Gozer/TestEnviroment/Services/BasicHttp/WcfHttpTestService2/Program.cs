using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using Gozer.Contract;
using Gozer.Core.Clortho;
using TestClientInterfaces;

namespace WcfHttpTestService2
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Factory.GetServiceRegistrator("http://localhost:25723")
                .AddService<IWcfHttpTestService>("http://localhost:8082/Service", ServicesBinding.WebHttpBinding))
            {
                ServiceHost host = new ServiceHost(typeof(Service));
                host.Open();
                Console.WriteLine("Service Hosted 2 running");
                Console.Read();
            }
        }
    }
}
