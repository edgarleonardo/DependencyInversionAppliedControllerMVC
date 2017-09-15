using DependencyInversionAppliedControllerMVC.Controllers;

namespace DependencyInversionAppliedControllerMVC.Repository
{
    public class Repository : IRepository<Inform>
    {
        public Inform Get()
        {
            return new Inform();
        }
    }
}