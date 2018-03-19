using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestClientInterfaces;

namespace WcfHttpTestService2
{
    public class Service: IWcfHttpTestService
    {
        public string GetMeldung()
        {
            return "Hello World 2";
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
