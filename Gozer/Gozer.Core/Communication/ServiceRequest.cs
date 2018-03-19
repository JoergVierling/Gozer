using Gozer.Contract.Communication;
using Gozer.Core;

namespace Gozer.Core.Communication
{
    public class ServiceRequest: IServiceRequest
    {
        public string AssambliQualifiedName { get; set; }

        public ServiceRequest(string assambliQualifiedName)
        {
            AssambliQualifiedName = assambliQualifiedName;
        }
    }
}
