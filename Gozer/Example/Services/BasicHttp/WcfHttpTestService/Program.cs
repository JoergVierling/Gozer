using System;
using System.ServiceModel;
using Gozer.Clortho.WCF;
using Gozer.Contract;
using TestClientInterfaces;

namespace WcfHttpTestService2
{
    class Program
    {
        static void Main(string[] args)
        {
            IClorthoRegister register = ClorthoFactory.Register("http://localhost:25723");
            register.ConnectionEvent += RegisterOnConnectionErrorEvent;

            using (register.AddService<IWcfHttpTestService>("http://localhost:8082/Service", ServicesBinding.WebHttpBinding))
            {
                ServiceHost host = new ServiceHost(typeof(Service));
                host.Open();
                Console.WriteLine("Service Hosted 2 running");
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
