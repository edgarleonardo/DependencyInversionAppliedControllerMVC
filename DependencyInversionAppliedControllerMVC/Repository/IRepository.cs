
using DependencyInversionAppliedControllerMVC.Controllers;

namespace DependencyInversionAppliedControllerMVC.Repository
{
    public interface IRepository<T> where T : IInfoManager
    {
        T Get();
    }
}