using DependencyInversionAppliedControllerMVC.Controllers;
using DependencyInversionAppliedControllerMVC.Repository;
using StructureMap;

namespace DependencyInversionAppliedControllerMVC.DependencyResolutions
{
    public class StandardRegistry : Registry
    {
        public StandardRegistry()
        {
            Scan(scan =>
            {
                scan.TheCallingAssembly();
                scan.WithDefaultConventions();
                scan.AddAllTypesOf<IInfoManager>();
                scan.AddAllTypesOf<IRepository<Inform>>();
            });
        }
    }
}