using System;
using System.Web.Mvc;
using StructureMap;
using StructureMap.Graph;
using StructureMap.Pipeline;

namespace DependencyInversionAppliedControllerMVC.DependencyResolutions
{
    public class ControllerRegistrationConvention : IRegistrationConvention
    {
        public void Process(Type type, Registry registry)
        {
            if (type.IsSubclassOf((typeof(Controller))) && !type.IsAbstract)
            {
                registry.For(type).LifecycleIs(new UniquePerRequestLifecycle());
            }
        }

        public void ScanTypes(StructureMap.Graph.Scanning.TypeSet types, Registry registry)
        {

        }
    }
}