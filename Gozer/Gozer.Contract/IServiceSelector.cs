namespace Gozer.Contract
{
    public interface IServiceSelector
    {
        IService Get(string assambliQualifiedName, ISheldService sheldService);
    }
}