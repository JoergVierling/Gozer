using TestClientInterfaces;

namespace WcfHttpTestService1
{
    public class Service : IWcfHttpTestService
    {
        public string GetMeldung()
        {
            return "Hello World 1";
        }

        public bool IsAlive()
        {
            return true;
        }
    }
}