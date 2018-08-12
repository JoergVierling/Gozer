using System;
using System.ServiceModel;
using System.Threading;
using Gozer.Clortho;
using Gozer.Clortho.WCF;
using Gozer.Contract;
using Gozer.Contract.Communication;
using TestClientInterfaces;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press ESC to stop");
            do
            {
                while (!Console.KeyAvailable)
                {
                    try
                    {
                        //BasicHttp();
                        BasicNetTcp();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

        private static void BasicHttp()
        {
            Thread.Sleep(2000);

            IClortho request = ClorthoFactory.Get("http://localhost:25724");
            var channel = request.Get<IWcfHttpTestService>().Result;

            var found = request.HasOne<IWcfDuplexTestService>().Result;


            if (found)
            {
                var message = channel.GetMeldung();
                Console.WriteLine(message);
            }
            else
            {
                Console.WriteLine("No Service Found");
            }
        }

        private static void BasicNetTcp()
        {
            Thread.Sleep(2000);

            InstanceContext instanceContext = new InstanceContext(new CallbackImpl());

            IClortho request = ClorthoFactory.Get("http://localhost:25724", 0);
            request.ConnectionEvent += RegisterOnConnectionErrorEvent;

            IWcfDuplexTestService channel = request.GetDuplex<IWcfDuplexTestService>(instanceContext).Result;

            if (channel != null)
            {
                Console.WriteLine(channel.GetMeldung());
            }
            else
            {
                Console.WriteLine("No Service Found");
            }
        }

        private static void ShowApiInformation(IServiceDelivery serviceDelivery, string type)
        {
            Console.WriteLine("ShowApiInformation");
            Console.WriteLine($"Type: {type}");
            Console.WriteLine($"EndpointAdress: {serviceDelivery.EndpointAdress}");
            Console.WriteLine($"Binding: {serviceDelivery.Binding}");
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
                Console.WriteLine(connectionErrorEvent.Exception.Message);
            }
        }
    }

    class CallbackImpl : IWcfDuplexTestCallback
    {
        public void ReturnRuntime(string userName)
        {
            Console.WriteLine(userName);
        }
    }
}
