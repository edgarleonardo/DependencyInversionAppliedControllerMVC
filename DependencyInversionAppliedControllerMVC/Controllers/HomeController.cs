using System.Web.Mvc;
using DependencyInversionAppliedControllerMVC.Filters;
using DependencyInversionAppliedControllerMVC.Repository;

namespace DependencyInversionAppliedControllerMVC.Controllers
{
    public interface IInfoManager
    {        
        void SetInformation(string value);
    }

    public class Inform : IInfoManager
    {
        public string Message { get;private set; }
        public string Title { get; private set; }
       public Inform()
        {
            Message = "Welcome To The ";
        }
        public void SetInformation(string value)
        {
            Title = value;
            Message = Message + value;
        }
    }
    public class HomeController : Controller
    {
        private IRepository<Inform> _manager;
        public HomeController(IRepository<Inform> manager)
        {
            _manager = manager;
        }
        [Home("Home")]
        public ActionResult Index()
        {
            var model = _manager.Get();
            return View(model);
        }
        [Home("About")]
        public ActionResult About()
        {
            var model = _manager.Get();
            return View(model);
        }
        [Home("Contact")]
        public ActionResult Contact()
        {
            var model = _manager.Get();
            return View(model);
        }
    }
}