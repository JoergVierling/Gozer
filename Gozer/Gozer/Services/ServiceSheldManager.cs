using System;
using System.Collections.Generic;
using System.Linq;
using Gozer.Contract;
using Gozer.Contract.Communication;
using Gozer.Core;
using Gozer.Core.Communication;
using Gozer.Core.Health.Model;
using Microsoft.Extensions.Logging;

namespace Gozer.Options
{
    class ServiceSheldManager : IServiceSheldManager
    {
        
        private readonly ILogger _logger;
        private ISheldService _sheldService;
        private IServiceSelector _serviceSelector;

        public ServiceSheldManager(ILogger<IServiceSheldManager> logger, ISheldService sheldService, IServiceSelector serviceSelector)
        {
            _logger = logger;
            _sheldService = sheldService;
            _serviceSelector = serviceSelector;
        }

        public Guid AddService(IServiceDelivery serviceDelivery)
        {
            IService service = new Service(serviceDelivery);

            var existingService = _sheldService.FirstOrDefault(x => x.EndpointAdress.Equals(service.EndpointAdress));
            if (existingService != null)
            {
                _sheldService.Remove(existingService);
            }

            _sheldService.Add(service);

            return service.Guid;
        }

        public void Remove(Guid guid)
        {
            var service = _sheldService.FirstOrDefault(x => x.Guid.Equals(guid));

            if (service != null)
            {
                _sheldService.Remove(service);
            }

        }

        public IServiceDelivery Get(string assambliQualifiedName)
        {
            IService service = _serviceSelector.Get(assambliQualifiedName, _sheldService);

            IServiceDelivery delivery = null;

            if (service != null)
            {
                var isAlive = Health.Factory.IsServiceAlive(service);

                if (isAlive)
                {
                    service.LastCall = DateTime.Now;
                    delivery = new ServiceDelivery()
                    {
                        AssambliQualifiedName = service.AssambliQualifiedName,
                        EndpointAdress = service.EndpointAdress,
                        binding = service.Binding
                    };
                }
                else
                {
                    //Service is not Working Anymore
                    _sheldService.Remove(service);

                    return Get(service.AssambliQualifiedName);
                }
            }
            else
            {
                _logger.LogTrace($"No Service of {assambliQualifiedName} found");
            }

            return delivery;
        }

        public List<IServiceHealth> GetInventur()
        {
            List<IServiceHealth> heathStatus = _sheldService.Select(Health.Factory.GetServiceHealth).ToList();

            return heathStatus;
        }
    }
}
