using System.Collections.Generic;

namespace Gozer.Contract
{
    public interface ISheldService : IEnumerable<IService>
    {
        void Remove(IService service);
        void Add(IService service);
        void Update(IService service);
    }
}