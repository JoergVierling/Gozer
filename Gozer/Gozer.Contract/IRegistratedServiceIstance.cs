using System;
using System.Collections.Generic;
using System.Text;

namespace Gozer.Contract
{
    public interface IRegistratedServiceIstance : IDisposable
    {
        IGozerServer GozerServer { get; set; }
    }
}