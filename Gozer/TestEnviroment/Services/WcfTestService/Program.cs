using System;

namespace WcfTestService
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(HelloWorld));
            host.Open();
            Console.WriteLine("Service Hosted on http://localhost:8080/HelloWorldService/HelloWorld/");
            Console.Read();
        }
    }
}
