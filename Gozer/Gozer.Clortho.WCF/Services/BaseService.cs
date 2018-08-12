using System;
using System.Collections.Generic;
using System.Text;
using Gozer.Contract.Health;

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
    }
}