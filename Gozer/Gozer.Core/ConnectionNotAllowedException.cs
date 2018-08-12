using System;
namespace Gozer.Core
{
    public class ConnectionNotAllowedException : Exception
    {
        public ConnectionNotAllowedException(string message) : base(message)
        {
        }
    }
}