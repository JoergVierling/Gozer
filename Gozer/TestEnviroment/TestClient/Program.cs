using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading;
using Gozer.Contract;
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

            var channel = Factory.GetServiceConsumer("http://localhost:25723")
                .Get<IWcfHttpTestService>();

            var message = channel.GetMeldung();

            Console.WriteLine(message);
        }

        private static void BasicNetTcp()
        {
            Thread.Sleep(2000);

            InstanceContext
                 a = new InstanceContext(new CallbackImpl());

            var channel = Factory.GetServiceConsumer("http://localhost:25723")
                .GetDuplex<IWcfDuplexTestService>(a);

            Console.WriteLine(channel.GetMeldung());
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
