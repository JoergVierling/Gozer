using Gozer.Health;

namespace Gozer.CommonTest
{
    public class MockServiceHealthFunctions:IServiceHealthFunctions
    {
        public bool IsServiceAlive()
        {
            return true;
        }
    }
}