using System;
using System.Collections.Generic;
using Gozer.Contract.Communication;
using Gozer.Contract.Health;

namespace Gozer.Contract
{
    public interface IServiceSheldManager
    {
        Guid? AddService(IServiceDelivery serviceDelivery);
        void Remove(Guid guid);
        IServiceDelivery Get(string assambliQualifiedName);

        List<IServiceHealth> GetInventur();
    }
}