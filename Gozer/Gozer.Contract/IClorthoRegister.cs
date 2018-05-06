using System;
using System.ServiceModel;
using System.Threading.Tasks;
using Gozer.Contract.Communication;
using Gozer.Core.Health.Contract;
using Gozer.Contract;
using System.Security.Cryptography.X509Certificates;

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