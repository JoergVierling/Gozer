using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Gozer.Options
{
    public class ServiceHolding
    {
        public int ServiceWatchTimeIntervall { get; set; }
        public int SecondChanceTimeIntervall { get; set; }

        public ServiceHolding()
        {
            ServiceWatchTimeIntervall = 100;
            SecondChanceTimeIntervall = 200;
        }
    }
}