using System;
using Gozer.Contract;

namespace DbShelterService
{
    public class Service : IService
    {
        public Guid Guid { get; set; }
        public string AssambliQualifiedName { get; set; }
        public ServicesBinding Binding { get; set; }
        public string EndpointAdress { get; set; }
        public DateTime LastCall { get; set; }
    }
}

