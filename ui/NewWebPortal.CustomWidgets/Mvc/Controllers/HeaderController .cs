using System.Web.Mvc;
using Telerik.Sitefinity.Mvc;

namespace NewWebPortal.CustomWidgets.Mvc.Controllers
{
    [ControllerToolboxItem(Name = "Header", Title = "Header", SectionName = "Custom Widgets")]
    public class HeaderController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
