using System;
using System.Collections.Generic;
using System.Text;

namespace Gozer.Core
{
    public class MaxWaitingTimeException : Exception
    {
        public MaxWaitingTimeException(string message) : base(message)
        {
        }
    }
}