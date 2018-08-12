using Gozer.Clortho.WebApi.Core.FactoryClasses;
using Gozer.Contract;
using Gozer.Core;

namespace Gozer.Clortho.WebApi.Core
{
    public class ClorthoFactory
    {
        public static IClorthoRegister Register(string gozerServer)
        {
            return new ClorthoRegister(new GozerServer(gozerServer));
        }
    }
}