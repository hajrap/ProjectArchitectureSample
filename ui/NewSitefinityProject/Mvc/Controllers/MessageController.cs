using NewSitefinityProject.Mvc.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Sitefinity.Mvc;

namespace NewSitefinityProject.Mvc.Controllers
{
    [ControllerToolboxItem(Name = "Message", Title = "Message", SectionName = "MVC Widgets")]
    public class MessageController : Controller
    {
        [Category("String Properties")]
        public string Text { get; set; }
        [Category("Integer Properties")]
        public int Repeat {
            get
            {
                return this.repeat;
            }
            set
            {
                this.repeat = value;
            }
        }

        // GET: Message
        public ActionResult Index()
        {
            var msg = new MessageModel()
            {
                Text = this.Text,
                Repeat = this.Repeat
            };
            return View("default", msg);
        }
        private int repeat = 1;
    }
}