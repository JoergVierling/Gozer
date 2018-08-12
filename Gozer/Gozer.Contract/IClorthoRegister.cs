using System;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using Gozer.Contract.Health;

namespace Gozer.Contract
{
    public interface IClorthoRegister
    {
        event EventHandler<IConnectionStatusChangedEvent> ConnectionEvent;

        Task<IRegistratedServiceIstance> AddService<T>(string endpoint, ServicesBinding binding)
            where T : IServicesHealthConnection;

        Task<IRegistratedServiceIstance> AddService<T>(string endpoint, ServicesBinding binding, X509Certificate2 cert)
            where T : IServicesHealthConnection;
    }
}