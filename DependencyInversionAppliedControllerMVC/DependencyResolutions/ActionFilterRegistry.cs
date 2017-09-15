using System;
using System.Web.Mvc;
using StructureMap;

namespace DependencyInversionAppliedControllerMVC.DependencyResolutions
{
    public class ActionFilterRegistry : Registry
    {
        public ActionFilterRegistry(Func<IContainer> containerFactory)
        {
            For<IFilterProvider>().Use(
                new StructureMapFilterProvider(containerFactory));

            Policies.SetAllProperties(x =>
                x.Matching(p =>
                    p.DeclaringType.IsSubclassOf(typeof(ActionFilterAttribute)) &&
                    p.DeclaringType.Namespace.StartsWith("GoogleDfpCaribeIntegration") &&
                    !p.PropertyType.IsPrimitive &&
                    p.PropertyType != typeof(string)));
        }
    }
}