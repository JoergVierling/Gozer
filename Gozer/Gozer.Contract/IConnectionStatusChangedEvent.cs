using System;

namespace Gozer.Contract
{
    public interface IConnectionStatusChangedEvent
    {
        Exception Exception { get; set; }
        bool Succes { get; set; }
    }
}