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
    }
}