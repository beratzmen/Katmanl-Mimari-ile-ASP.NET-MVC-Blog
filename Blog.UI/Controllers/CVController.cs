using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.UI.Controllers
{
    public class CVController : Controller
    {
        [Route("Hakkimda")]
        public ActionResult Index()
        {
            return View();
        }
    }
}