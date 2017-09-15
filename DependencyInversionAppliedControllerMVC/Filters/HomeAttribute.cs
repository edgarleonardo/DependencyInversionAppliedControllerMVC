using System.Web.Mvc;
using DependencyInversionAppliedControllerMVC.Controllers;
using DependencyInversionAppliedControllerMVC.Repository;
using StructureMap.Attributes;

namespace DependencyInversionAppliedControllerMVC.Filters
{
    public class HomeAttribute : ActionFilterAttribute
    {
        public string Description { get; set; }

        public HomeAttribute(string description)
        {
            Description = description;
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var viewResult = filterContext.Result as ViewResult;

            if (viewResult != null && viewResult.Model is IInfoManager)
            {
                ((IInfoManager)viewResult.Model).SetInformation(Description);
            }
        }
    }
}