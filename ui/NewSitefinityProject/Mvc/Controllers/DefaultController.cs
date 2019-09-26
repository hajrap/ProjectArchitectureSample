using System.Web.Mvc;
using Telerik.Sitefinity.Mvc;

namespace NewSitefinityProject.Mvc.Controllers
{
    [ControllerToolboxItem(Name = "Default", Title = "Default", SectionName = "MVC Widgets")]
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }
    }
}