using System;
using Gozer.Contract.Communication;

namespace Gozer.Core.Health.Model
{
    public interface IServiceHealth : IServiceDelivery
    {
        bool IsAlive { get; set; }
        DateTime LastCall { get; set; }
        string CpuUsage{ get; set; }
        string FreeMemory { get; set; }
    }
}