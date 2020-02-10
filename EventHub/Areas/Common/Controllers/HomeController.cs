using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventHub.Areas.Common.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        // GET: Common/Home
        public ActionResult Index()
        {
            // Bk chodi Kr di
            return View();
        }
    }
}