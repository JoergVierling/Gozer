namespace Gozer.Contract.Communication
{
    public interface IServiceDelivery
    {
        string AssambliQualifiedName { get; set; }
        ServicesBinding Binding { get; set; }
        string EndpointAdress { get; set; }
        byte[] Signature { get; set; }
    }
}