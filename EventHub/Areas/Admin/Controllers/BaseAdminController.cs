using EventHub.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventHub.Areas.Admin.Controllers
{
    // class to make object of Admin Business Layer
    public class BaseAdminController : Controller
    {
        //private ListEventBs objBs;
        protected AdminBs objBs;

        public BaseAdminController()
        {
            objBs = new AdminBs();
        }
    }
}