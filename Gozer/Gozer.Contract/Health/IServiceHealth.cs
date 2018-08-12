using System;
using Gozer.Contract.Communication;

namespace Gozer.Contract.Health
{
    public interface IServiceHealth : IServiceDelivery
    {
        bool IsAlive { get; set; }
        DateTime LastCall { get; set; }
    }
}