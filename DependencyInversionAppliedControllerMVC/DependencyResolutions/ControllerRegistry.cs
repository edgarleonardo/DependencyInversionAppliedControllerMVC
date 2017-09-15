using StructureMap;

namespace DependencyInversionAppliedControllerMVC.DependencyResolutions
{
    public class ControllerRegistry : Registry
    {
        public ControllerRegistry()
        {
            Scan(scan =>
            {
                scan.TheCallingAssembly();
                scan.With(new ControllerRegistrationConvention());
            });
        }
    }
}