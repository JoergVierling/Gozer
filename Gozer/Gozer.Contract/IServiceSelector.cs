using System;
using System.Collections.Generic;
using System.Text;

namespace Gozer.Contract
{
    public interface IServiceSelector
    {
        IService Get(string assambliQualifiedName, ISheldService sheldService);
    }
}