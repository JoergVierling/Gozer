using Gozer.Contract.Communication;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gozer.Contract
{
    public interface IAuthorizeManager
    {
        bool IsSignitureValid(IServiceDelivery serviceRegister);

        bool IsHostAllowed(IServiceDelivery serviceRegister);
    }
}
