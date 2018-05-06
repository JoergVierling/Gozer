using System;
using System.Collections.Generic;
using System.Text;
using Gozer.Contract.Health;
using Gozer.Core.Health.Contract;
using Gozer.Core.Health.Model;

namespace Gozer.Clortho.WCF.Services
{
    public class BaseService : IServicesHealthConnection
    {
        private IHealthClient _healthClient;

        public BaseService(IHealthClient healthClient)
        {
            _healthClient = healthClient;
        }

        public bool IsAlive()
        {
            return _healthClient.IsAlive();
        }

        public string GetCpuLoad()
        {
            return _healthClient.GetCpuLoad();
        }

        public string GetMemLoad()
        {
            return _healthClient.GetMemLoad();
        }
    }
}