﻿using System;
using System.ServiceModel;
using Gozer.Clortho.WCF;
using Gozer.Contract;
using TestClientInterfaces;

namespace WcfDuplexTestService2
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = "net.tcp://localhost:9011/service";

            IClorthoRegister register = ClorthoFactory.Register("http://localhost:25724");
            register.ConnectionEvent += RegisterOnConnectionErrorEvent;

            using (register.AddService<IWcfDuplexTestService>(url, ServicesBinding.NetTcpBinding))
            {
                ServiceHost duplex = new ServiceHost(typeof(Service));
                duplex.AddServiceEndpoint(typeof(IWcfDuplexTestService), new NetTcpBinding(), url);
                duplex.Open();

                Console.WriteLine("Service Hosted NetTcp 2 running");
                Console.Read();
            }
        }

        private static void RegisterOnConnectionErrorEvent(object sender, IConnectionStatusChangedEvent connectionErrorEvent)
        {
            if (connectionErrorEvent.Succes)
            {
                Console.WriteLine("Connected");
            }
            else
            {
                Console.WriteLine($"Fehler in der Komponente {connectionErrorEvent.Exception.Source}");
                Console.WriteLine($"{connectionErrorEvent.Exception.Message}");
            }
        }
    }
}
