using Gozer.Contract;

namespace Gozer.Core
{
    public class GozerServer : IGozerServer
    {
        public string BasUrl { get; }

        public GozerServer(string url)
        {
            BasUrl = url;
        }
    }
}