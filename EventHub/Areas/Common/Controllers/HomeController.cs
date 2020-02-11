using EventHub.BLL;
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
        private EventBs objEventBs;
        public HomeController()
        {
            objEventBs = new EventBs();
        }
        // GET: Common/Home
        public ActionResult Index()
        {
            var output = objEventBs.GetALL();
            return View(output);
        }

        public ActionResult EventDetail(int id)
        {
            var output = objEventBs.GetByID(id);
            if (output == null)
                return HttpNotFound();
            return View(output);
        }
    }
}