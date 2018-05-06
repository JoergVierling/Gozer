using Gozer.Contract;

namespace Gozer.Clortho
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