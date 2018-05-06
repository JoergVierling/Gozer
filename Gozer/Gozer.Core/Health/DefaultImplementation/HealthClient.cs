using System.Diagnostics;
using Gozer.Contract.Health;

namespace Gozer.Core.Health.DefaultImplementation
{
    public class HealthClient : IHealthClient
    {
        public bool IsAlive()
        {
            return true;
        }

        public string GetCpuLoad()
        {
            var cpuCounter = new PerformanceCounter
            {
                CategoryName = "Processor",
                CounterName = "% Processor Time",
                InstanceName = "_Total"
            };

            return cpuCounter.NextValue() + "%";
        }

        public string GetMemLoad()
        {
            var cpuCounter = new PerformanceCounter
            {
                CategoryName = "Memory",
                CounterName = "Available MBytes",
                InstanceName = null
            };

            return cpuCounter.NextValue() + "MB";
        }
    }
}