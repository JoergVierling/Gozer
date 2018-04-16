using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Gozer.Contract
{
    public interface ISheldService : IEnumerable<IService>
    {
        void Remove(IService service);
        void Add(IService service);
        void Update(IService service);
    }
}
