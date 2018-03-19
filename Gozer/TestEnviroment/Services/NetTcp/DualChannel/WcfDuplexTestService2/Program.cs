﻿using System;
using System.ServiceModel;
using Gozer.Contract;
using Gozer.Core.Clortho;
using TestClientInterfaces;

namespace WcfDuplexTestService2
{
    class Program
    {
        static void Main(string[] args)
        {

            var url = "net.tcp://localhost:9001/service";

            using (Factory.GetServiceRegistrator("http://localhost:25723")
                .AddService<IWcfDuplexTestService>(url, ServicesBinding.NetTcpBinding))
            {
                ServiceHost duplex = new ServiceHost(typeof(Service));
                duplex.AddServiceEndpoint(typeof(IWcfDuplexTestService), new NetTcpBinding(), url);
                duplex.Open();

                Console.WriteLine("Service Hosted NetTcp 2 running");
                Console.Read();
            }
        }
    }
}
