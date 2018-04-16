using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Gozer.Contract;
using JetBrains.Annotations;

namespace DbShelterService
{
    public class DbShelter : ISheldService
    {
        private ShelterContext _shelterContext;

        public DbShelter(ShelterContext context)
        {
            _shelterContext = context;
        }

        public IEnumerator<IService> GetEnumerator()
        {
            return _shelterContext.Service.Select(x => (IService) x).ToList().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IService Get(string key)
        {
            var element = _shelterContext.Service.FirstOrDefault(x => x.AssambliQualifiedName == key);
            element.LastCall = DateTime.Now;

            _shelterContext.Service.Update(element);

            _shelterContext.SaveChanges();

            return element;
        }

        public void Remove(IService service)
        {
            var element = _shelterContext.Service.FirstOrDefault(x => x.Guid == service.Guid);
            _shelterContext.Service.Remove(element);
        }

        public void Add([NotNull] IService service)
        {
            var serviceElement = new Service();

            serviceElement.Guid = serviceElement.Guid;
            serviceElement.AssambliQualifiedName = service.AssambliQualifiedName;
            serviceElement.Binding = service.Binding;
            serviceElement.EndpointAdress = service.EndpointAdress;
            serviceElement.LastCall = service.LastCall;

            _shelterContext.Service.Add(serviceElement);
            _shelterContext.SaveChanges();
        }

        public void Update(IService service)
        {
            var serviceElement = _shelterContext.Service.FirstOrDefault(x => x.Guid == service.Guid);

            serviceElement.AssambliQualifiedName = service.AssambliQualifiedName;
            serviceElement.Binding = service.Binding;
            serviceElement.EndpointAdress = service.EndpointAdress;
            serviceElement.LastCall = service.LastCall;

            _shelterContext.Service.Update(serviceElement);
            _shelterContext.SaveChanges();
        }
    }
}