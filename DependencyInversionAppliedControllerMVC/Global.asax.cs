using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using DependencyInversionAppliedControllerMVC.DependencyResolutions;
using StructureMap;

namespace DependencyInversionAppliedControllerMVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static IContainer Container
        {
            get;
            set;
        }
        public IContainer ContainerObjects { get { return (IContainer)HttpContext.Current.Items["_Container"]; } set { HttpContext.Current.Items["_Container"] = value; } }
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Container = new Container();
            DependencyResolver.SetResolver(
                        new StructureMapDependencyResolver(() => Container));
            Container.Configure(
                  cfg =>
                  {
                      cfg.AddRegistry(new StandardRegistry());
                      cfg.AddRegistry(new ControllerRegistry());
                      //cfg.AddRegistry(new GoogleRegistry());
                      cfg.AddRegistry(new MvcRegistry());
                      cfg.AddRegistry(new ActionFilterRegistry(() => Container));
                  });
        }
        public void Application_BeginRequest()
        {
            
        }
        public void Application_EndRequest()
        {
            if (ContainerObjects != null)
            {
                ContainerObjects.Dispose();
                ContainerObjects = null;
            }
        }
    }
}
