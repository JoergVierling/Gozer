using System.Diagnostics;
using System.ServiceModel;
using Gozer.Clortho.WCF.Services;
using Gozer.Core.Health.DefaultImplementation;
using TestClientInterfaces;

namespace WcfDuplexTestService2
{
    public class Service : BaseService, IWcfDuplexTestService
    {
        public string GetMeldung()
        {
            Stopwatch sp = new Stopwatch();
            sp.Start();
            IWcfDuplexTestCallback callback = OperationContext.Current.GetCallbackChannel<IWcfDuplexTestCallback>();

            sp.Stop();
            callback.ReturnRuntime(sp.Elapsed.ToString());
            return "Hello World Net Tcp 2";
            
        }

        public Service() : base(new HealthClient())
        {
        }
    }
}
