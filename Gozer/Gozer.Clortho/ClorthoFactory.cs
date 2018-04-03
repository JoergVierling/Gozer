
using Gozer.Clortho;
using Gozer.Contract;

namespace Gozer.Clortho
{
    public class ClorthoFactory
    {
        public static IClortho Get(string gozerServer)
        {
            return Get(gozerServer, 1);
        }
        public static IClortho Get(string gozerServer, int waitTime)
        {
            return new FactoryClasses.Clortho(new GozerServer(gozerServer), waitTime);
        }

        public static IClorthoRegister Register(string gozerServer)
        {
            return new FactoryClasses.ClorthoRegister(new GozerServer(gozerServer));
        }
    }
}
