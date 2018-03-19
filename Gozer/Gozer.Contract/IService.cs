using System;

namespace Gozer.Contract
{
    public interface IService
    {
        Guid Guid { get; set; }
        string AssambliQualifiedName { get; set; }
        ServicesBinding Binding { get; set; }
        string EndpointAdress { get; set; }
        DateTime LastCall { get; set; }
    }
}