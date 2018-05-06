using System;
using System.Collections.Generic;
using System.Linq;
using Gozer.Configuration;
using Gozer.Contract;
using Gozer.Contract.Communication;
using Gozer.Core;
using Gozer.Core.Communication;
using Gozer.Core.Health;
using Gozer.Core.Health.Model;
using Microsoft.Extensions.Logging;
using Factory = Gozer.Health.Factory;

namespace Gozer.Options
{
    class ServiceSheldManager : IServiceSheldManager
    {
        private readonly ILogger _logger;
        private ISheldService _sheldService;
        private IServiceSelector _serviceSelector;

        private GozerServerOptions _options;

        public ServiceSheldManager(ILogger<IServiceSheldManager> logger, ISheldService sheldService,
            IServiceSelector serviceSelector, GozerServerOptions options)
        {
            _logger = logger;
            _sheldService = sheldService;
            _serviceSelector = serviceSelector;

            _options = options;
        }

        public Guid? AddService(IServiceDelivery serviceDelivery)
        {
            IService service = new Service(serviceDelivery);
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
                var isAlive = Factory.IsServiceAlive(service);

                if (isAlive)
                {
                    service.LastCall = DateTime.Now;
                    _sheldService.Update(service);

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
            List<IServiceHealth> heathStatus = _sheldService.Select(Factory.GetServiceHealth).ToList();

            return heathStatus;
        }
    }
}