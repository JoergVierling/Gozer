using System;
using System.Collections.Generic;
using System.Text;

namespace Gozer.Contract
{
    public interface IConnectionStatusChangedEvent
    {
        Exception Exception { get; set; }
        bool Succes { get; set; }
    }
}