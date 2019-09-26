using NewWebPortal.ApplicationCore;
using NewWebPortal.ApplicationCore.Entities;
using NewWebPortal.ApplicationCore.Interfaces.Services;
using System.Web.Mvc;
using Telerik.Sitefinity.Mvc;

namespace NewWebPortal.CustomWidgets.Mvc.Controllers
{
    [ControllerToolboxItem(Name = "Products", Title = "Products", SectionName = "Custom Widgets")]
    public class ProductsController: Controller
    {
        private readonly IProductService _iProductService;

        public ProductsController(IProductService iProductService)
        {
            this._iProductService = iProductService;
        }

        public ActionResult Index()
        {
            return View(_iProductService.Get());
        }
    }
}
