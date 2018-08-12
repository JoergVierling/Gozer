using System.Diagnostics;
using System.ServiceModel;
using TestClientInterfaces;

namespace WcfDuplexTestService1
{
    public class Service : IWcfDuplexTestService
    {
        public string GetMeldung()
        {
            Stopwatch sp = new Stopwatch();
            sp.Start();
            IWcfDuplexTestCallback callback = OperationContext.Current.GetCallbackChannel<IWcfDuplexTestCallback>();

            sp.Stop();
            callback.ReturnRuntime(sp.Elapsed.ToString());
            return "Hello World Net Tcp 1";
        }

        public bool IsAlive()
        {
            return true;
        }

    }
}