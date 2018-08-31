using Gozer.Contract;
using Gozer.Contract.Communication;

namespace Gozer.CommonTest
{
    public class MockAuthorizeManager:IAuthorizeManager
    {
        public bool IsSignitureValid(IServiceDelivery serviceRegister)
        {
            return true;
        }

        public bool IsHostAllowed(IServiceDelivery serviceRegister)
        {
            return true;
        }
    }
}