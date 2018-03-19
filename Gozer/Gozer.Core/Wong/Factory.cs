using Gozer.Core.Wong.FactoryClasses;

namespace Gozer.Core.Wong
{
    public class Factory
    {
        public static Consume GetServiceConsumer(string karmarTajServer)
        {
            return new Consume(new Wong(karmarTajServer));
        }

        public static Register GetServiceRegistrator(string karmarTajServer)
        {
            return new Register(new Wong(karmarTajServer));
        }
    }
}
