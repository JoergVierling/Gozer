using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading;
using Gozer.Contract;
using Gozer.Contract.Communication;
using Gozer.Core;
using Gozer.Core.Clortho;
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

            var request = Factory.Request("http://localhost:25723");
            var channel = request.Get<IWcfHttpTestService>();

            if (request.HasOne<IWcfDuplexTestService>())
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

            InstanceContext
                 a = new InstanceContext(new CallbackImpl());

            var request = Factory.Request("http://localhost:25723");
            var channel = request.GetDuplex<IWcfDuplexTestService>(a);

            if (request.HasOne<IWcfDuplexTestService>())
            {
                ShowApiInformation(request.GetApiInformation<IWcfDuplexTestService>(),
                    typeof(IWcfDuplexTestService).ToString());

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
            Console.WriteLine($"Binding: {serviceDelivery.binding}");

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
