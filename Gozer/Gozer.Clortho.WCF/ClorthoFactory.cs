using Gozer.Clortho.WCF.FactoryClasses;
using Gozer.Contract;
using Gozer.Core;

namespace Gozer.Clortho.WCF
{
    public class ClorthoFactory
    {
        public static IClortho Get(string gozerServer)
        {
            return Get(gozerServer, 1);
        }
        public static IClortho Get(string gozerServer, int waitTime)
        {
            return new WCF.FactoryClasses.Clortho(new GozerServer(gozerServer), waitTime);
        }

        public static IClorthoRegister Register(string gozerServer)
        {
            return new ClorthoRegister(new GozerServer(gozerServer));
        }
    }
}
