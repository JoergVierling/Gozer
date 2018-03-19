using Gozer.Core.Clortho.FactoryClasses;

namespace Gozer.Core.Clortho
{
    public class Factory
    {
        public static Consume GetServiceConsumer(string gozerServer)
        {
            return new Consume(new Clortho(gozerServer));
        }

        public static Register GetServiceRegistrator(string gozerServer)
        {
            return new Register(new Clortho(gozerServer));
        }
    }
}
