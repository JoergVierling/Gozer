using Gozer.Contract.Communication;

namespace Gozer.Contract
{
    public interface IAuthorizeManager
    {
        bool IsSignitureValid(IServiceDelivery serviceRegister);

        bool IsHostAllowed(IServiceDelivery serviceRegister);
    }
}