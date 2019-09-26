using System.Web.Mvc;
using Telerik.Sitefinity.Mvc;

namespace NewWebPortal.CustomWidgets.Mvc.Controllers
{
    [ControllerToolboxItem(Name = "Footer", Title = "Footer", SectionName = "Custom Widgets")]
    public class FooterController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
