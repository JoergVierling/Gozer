using System;
using System.Collections.Generic;
using System.Text;
using Gozer.Contract;

namespace Gozer.Core
{
    public class ConnectionStatusChangedEvent : IConnectionStatusChangedEvent
    {
        public Exception Exception { get; set; }
        public bool Succes { get; set; }

        public ConnectionStatusChangedEvent(bool isConnected)
        {
            Succes = isConnected;
        }

        public ConnectionStatusChangedEvent(Exception exception)
        {
            Exception = exception;
        }
    }
}