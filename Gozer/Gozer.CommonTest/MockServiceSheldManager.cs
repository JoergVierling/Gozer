using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Gozer.Contract;
using Gozer.Contract.Communication;
using Gozer.Contract.Health;
using Gozer.Core;
using Gozer.Core.Communication;
using Gozer.Endpoints.Manager;
using Gozer.Health.Model;
using Newtonsoft.Json.Serialization;

namespace Gozer.CommonTest
{
    public class MockServiceSheldManager : IServiceSheldManager
    {
        List<IService> services;

        public MockServiceSheldManager()
        {
            services = new List<IService>();

            var service = new Service("MockAssambliQualifiedName", ServicesBinding.WebApi, "localHostAddress");
            service.Guid = Guid.Parse("fe4947d7-0293-4b93-8b74-2344536b81a0");

            services.Add(service);
        }

        public Guid? AddService(IServiceDelivery serviceDelivery)
        {
            var service = new Service(serviceDelivery);
            service.Guid = Guid.Parse("8ee99672-e455-46b1-a5b3-7774eaa80722");

            services.Add(service);

            return service.Guid;
        }

        public void Remove(Guid guid)
        {
            services.Remove(services.First(x => x.Guid == guid));
        }

        public IServiceDelivery Get(string assambliQualifiedName)
        {
            var service = services.First(x => x.AssambliQualifiedName.Equals(assambliQualifiedName));

            return new ServiceDelivery()
            {
                AssambliQualifiedName = service.AssambliQualifiedName,
                EndpointAdress = service.EndpointAdress,
                Binding = service.Binding
            };
        }

        public List<IServiceHealth> GetInventur()
        {
            return services.Select(x => new ServiceHealth()
                {
                    AssambliQualifiedName = x.AssambliQualifiedName,
                    EndpointAdress = x.EndpointAdress,
                    Binding = x.Binding,
                    IsAlive = true,
                    LastCall = new DateTime(2018, 08, 31, 20, 15, 00)
                })
                .Select(x => x as IServiceHealth).ToList();
        }
    }
}