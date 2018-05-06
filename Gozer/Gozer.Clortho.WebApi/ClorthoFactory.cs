using Gozer.Clortho.WebApi.FactoryClasses;
using Gozer.Contract;

namespace Gozer.Clortho.WebApi
{
    public class ClorthoFactory
    {

        public static IClorthoRegister Register(string gozerServer)
        {
            return new ClorthoRegister(new GozerServer(gozerServer));
        }
    }
}
