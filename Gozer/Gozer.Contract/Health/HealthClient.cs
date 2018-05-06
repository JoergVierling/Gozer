namespace Gozer.Contract.Health
{
   public interface IHealthClient
    {
        bool IsAlive();

        string GetCpuLoad();

        string GetMemLoad();
    }
}
