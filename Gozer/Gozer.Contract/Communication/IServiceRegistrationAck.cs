using System;

namespace Gozer.Contract.Communication
{
    public interface IServiceRegistrationAck
    {
        Guid ServiceID { get; set; }
    }
}