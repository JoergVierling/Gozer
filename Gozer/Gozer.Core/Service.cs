using System;
using Gozer.Contract;
using Gozer.Contract.Communication;
using Gozer.Core;
using Gozer.Core.Communication;

namespace Gozer.Core
{
    public class Service : IService
    {
        public Guid Guid { get; set; }

        public string AssambliQualifiedName { get; set; }
        public ServicesBinding Binding { get; set; }
        public string EndpointAdress { get; set; }

        public DateTime LastCall { get; set; }


        public Service(IServiceDelivery serviceDelivery) : this(serviceDelivery.AssambliQualifiedName, serviceDelivery.binding, serviceDelivery.EndpointAdress)
        {
        }

        public Service(string assambliQualifiedName, ServicesBinding binding, string endpointAdress)
        {
            Guid = Guid.NewGuid();

            AssambliQualifiedName = assambliQualifiedName;
            Binding = binding;
            EndpointAdress = endpointAdress;
        }
    }
}
