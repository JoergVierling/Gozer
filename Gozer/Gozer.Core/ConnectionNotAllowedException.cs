using System;
using System.Collections.Generic;
using System.Text;

namespace Gozer.Core
{
    public class ConnectionNotAllowedException : Exception
    {
        public ConnectionNotAllowedException(string message) : base(message) { }

    }
}
