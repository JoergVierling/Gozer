using System;
using System.ServiceModel;
using Gozer.Clortho;
using Gozer.Contract;
using TestClientInterfaces;

namespace WcfHttpTestService1
{
    class Program
    {
        static void Main(string[] args)
        {
            var register = ClorthoFactory.Register("http://localhost:25723");
            register.ConnectionEvent+=RegisterOnConnectionErrorEvent;
            
            using (register.AddService<IWcfHttpTestService>("http://localhost:8081/Service", ServicesBinding.WebHttpBinding))
            {
                //ServiceHost host = new ServiceHost(typeof(Service));
                //host.Open();
                Console.WriteLine("Service Hosted 1 running");
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
