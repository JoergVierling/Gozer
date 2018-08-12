using TestClientInterfaces;

namespace WcfHttpTestService
{
    public class Service : IWcfHttpTestService
    {
        public string GetMeldung()
        {
            return "Hello World 2";
        }

        public bool IsAlive()
        {
            return true;
        }
    }
}