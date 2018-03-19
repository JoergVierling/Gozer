using System;
using System.Threading;
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
                        Thread.Sleep(2000);

                        var channel = Factory.GetServiceConsumer("http://localhost:25723")
                            .Get<IWcfHttpTestService>();

                        var message = channel.GetMeldung();

                        Console.WriteLine(message);

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

        }


        //static void Main(string[] args)
        //{
        //    RegistratedServiceIstance registeredService = 
        //        Factory.GetServiceRegistrator("http://localhost:25723").AddService<ITestService>("", ServicesKind.WcfServices);
        //}
    }
}
