using System;
using System.ServiceModel;
using Gozer.Clortho.WCF;
using Gozer.Contract;
using TestClientInterfaces;

namespace WcfDuplexTestService1
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = "net.tcp://localhost:9010/service";

            IClorthoRegister register = ClorthoFactory.Register("http://localhost:25723");
            register.ConnectionEvent += RegisterOnConnectionErrorEvent;

            using (register.AddService<IWcfDuplexTestService>(url, ServicesBinding.NetTcpBinding))
            {
                ServiceHost duplex = new ServiceHost(typeof(Service));
                duplex.AddServiceEndpoint(typeof(IWcfDuplexTestService), new NetTcpBinding(), url);
                duplex.Open();

                Console.WriteLine("Service Hosted NetTcp 1 running");
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
            }
        }
    }
}
