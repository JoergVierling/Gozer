using System.Diagnostics;
using System.ServiceModel;
using TestClientInterfaces;

namespace WcfDuplexTestService1
{
    public class Service : IWcfDuplexTestService
    {
        public string GetMeldung()
        {
            Stopwatch sp = new Stopwatch();
            sp.Start();
            IWcfDuplexTestCallback callback = OperationContext.Current.GetCallbackChannel<IWcfDuplexTestCallback>();

            sp.Stop();
            callback.ReturnRuntime(sp.Elapsed.ToString());
            return "Hello World Net Tcp 1";

        }

        public bool IsAlive()
        {
            return true;
        }

        public string GetCpuLoad()
        {
            var cpuCounter = new PerformanceCounter();
            cpuCounter.CategoryName = "Processor";
            cpuCounter.CounterName = "% Processor Time";
            cpuCounter.InstanceName = "_Total";

            return cpuCounter.NextValue() + "%";
        }

        public string GetMemLoad()
        {
            var cpuCounter = new PerformanceCounter("Memory", "Available MBytes", null);

            return cpuCounter.NextValue() + "MB";
        }
    }
}
