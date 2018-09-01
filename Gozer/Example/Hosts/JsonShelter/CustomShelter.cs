using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Gozer.Contract;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;

namespace JsonShelter
{
    public class CustomShelter : ISheldService
    {
        private JsonRepository _reader;
        private bool _isSynced;
        private List<IService> _services;

        public List<IService> Services
        {
            get { return CheckSync(() => _services); }
            set => _services = value;
        }

        public CustomShelter(JsonRepository reader)
        {
            _reader = reader;
            _isSynced = false;

            Services = new List<IService>();
        }

        private void Sync()
        {
            var itemsSerialized = _reader.Read();
            var desirilizedList = JsonConvert.DeserializeObject<List<Service>>(itemsSerialized);

            _services = desirilizedList?.Select(x => x as IService).ToList() ?? new List<IService>();

            _isSynced = true;
        }

        public IEnumerator<IService> GetEnumerator()
        {
            return Services.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Remove(IService service)
        {
            Services.RemoveAll(service1 => service1.AssambliQualifiedName == service.AssambliQualifiedName
                                           && service1.EndpointAdress == service.EndpointAdress);

            Write(Services);
        }

        public void Add(IService service)
        {
            Services.Add(service);
            Write(Services);
        }

        public void Update(IService service)
        {

            Services.RemoveAll(service1 => service1.AssambliQualifiedName == service.AssambliQualifiedName 
                                           && service1.EndpointAdress == service.EndpointAdress);

            Services.Add(service);

            Write(Services);
        }

        public List<IService> CheckSync(Func<List<IService>> action)
        {
            if (!_isSynced)
            {
                Sync();
            }

            return action.Invoke();
        }

        public async void Write(List<IService> list)
        {
            var textList = JsonConvert.SerializeObject(list);

            await _reader.Write(textList);
        }
    }
}