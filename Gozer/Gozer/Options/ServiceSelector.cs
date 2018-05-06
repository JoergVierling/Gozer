using System.Linq;
using Gozer.Contract;

namespace Gozer.Options
{
    public class ServiceSelector : IServiceSelector
    {
        public IService Get(string assambliQualifiedName, ISheldService sheldService)
        {
            IService service = sheldService.Where(x => x.AssambliQualifiedName == assambliQualifiedName)
                .OrderBy(x => x.LastCall)
                .FirstOrDefault();

            return service;
        }
    }
}