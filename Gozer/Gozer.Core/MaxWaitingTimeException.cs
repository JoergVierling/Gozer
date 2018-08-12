using System;
namespace Gozer.Core
{
    public class MaxWaitingTimeException : Exception
    {
        public MaxWaitingTimeException(string message) : base(message)
        {
        }
    }
}