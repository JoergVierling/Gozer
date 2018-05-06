using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using Gozer.Configuration;
using Gozer.Contract;
using Gozer.Core;
using Gozer.Core.Health;
using JetBrains.Annotations;
using Factory = Gozer.Health.Factory;

namespace Gozer.Services
{
    public class ServiceChecker : IServiceChecker
    {
        private List<IService> _underWatch;
        private readonly ISheldService _sheldService;

        private Timer _secondChanceTimer;
        private Timer _watchTimer;


        public ServiceChecker(ISheldService sheldService, GozerServerOptions options)
        {
            _underWatch = new List<IService>();
            _sheldService = sheldService;


            _watchTimer = new Timer(options.ServiceHolding.ServiceWatchTimeIntervall) { Enabled = false, AutoReset = true };
            _watchTimer.Elapsed += (sender, args) => { Watch(_sheldService); };

            _secondChanceTimer = new Timer(options.ServiceHolding.SecondChanceTimeIntervall) { Enabled = false, AutoReset = true };
            _secondChanceTimer.Elapsed += (sender, args) => { SecondChance(_underWatch); };
        }

        public void Watch()
        {
            _watchTimer.Enabled = true;
            _secondChanceTimer.Enabled = true;
        }

        public void Stop()
        {
            _watchTimer.Enabled = false;
            _secondChanceTimer.Enabled = false;
        }

        public void Watch(ISheldService sheldService)
        {
            lock (_underWatch)
            {
                foreach (IService service in sheldService)
                {
                    var isAlive = IsAlive(service);

                    if (!isAlive)
                    {
                        sheldService.Remove(service);
                        _underWatch.Add(service);
                    }
                }
            }
        }

        public void SecondChance(List<IService> services)
        {
            lock (_underWatch)
            {

                foreach (IService service in _underWatch)
                {
                    var isAlive = IsAlive(service);

                    if (isAlive)
                    {
                        services.Add(service);
                    }
                }

                _underWatch = new List<IService>();
            }
        }

        public static bool IsAlive([NotNull] IService service)
        {
            return Factory.IsServiceAlive(service);
        }
    }
}
