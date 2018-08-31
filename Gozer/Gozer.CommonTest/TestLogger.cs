using Microsoft.Extensions.Logging;

namespace Gozer.CommonTest
{
    public static class TestLogger
    {
        public static ILogger<T> Create<T>()
        {
            return new LoggerFactory().CreateLogger<T>();
        }
    }
}