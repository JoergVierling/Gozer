using Gozer.Contract.Communication;

namespace Gozer.Core.Communication
{
    public class ServiceRequest : IServiceRequest
    {
        public string AssambliQualifiedName { get; set; }

        public ServiceRequest(string assambliQualifiedName)
        {
            AssambliQualifiedName = assambliQualifiedName;
        }
    }
}