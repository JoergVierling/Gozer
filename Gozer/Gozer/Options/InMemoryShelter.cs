using System.Collections;
using System.Collections.Generic;
using Gozer.Contract;

namespace Gozer.Services
{
    public class InMemoryShelter : ISheldService
    {
        private readonly List<IService> _service;

        public InMemoryShelter()
        {
            _service = new List<IService>();
        }

        public IEnumerator<IService> GetEnumerator()
        {
            return _service.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Remove(IService service)
        {
            _service.Remove(service);
        }

        public void Add(IService service)
        {
            _service.Add(service);
        }
    }
}
