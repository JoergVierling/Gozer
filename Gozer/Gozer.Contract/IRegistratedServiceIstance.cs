using System;

namespace Gozer.Contract
{
    public interface IRegistratedServiceIstance : IDisposable
    {
        IGozerServer GozerServer { get; set; }
    }
}