using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Gozer.Contract;
using JetBrains.Annotations;

namespace DbShelterImplementation
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
            return _shelterContext.Service.Select(x=>x as IService).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Remove(IService service)
        {
            var element=  _shelterContext.Service.FirstOrDefault(x => x.Guid == service.Guid);
            _shelterContext.Service.Remove(element);
        }

        public void Add([NotNull] IService service)
        {
            _shelterContext.Service.Add(service as Service);
            _shelterContext.SaveChanges();
        }
    }
}
