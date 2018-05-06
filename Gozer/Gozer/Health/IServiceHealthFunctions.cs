namespace Gozer.Health.Implementation
{
    public interface IServiceHealthFunctions
    {
        bool IsServiceAlive();
        string GetCpuUsage();
        string GetMemUsage();
    }
}