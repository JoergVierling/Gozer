namespace Microsoft.Extensions.DependencyInjection
{
    public interface IGozerServerBuilder
    {
        IServiceCollection Services { get; }
    }
}