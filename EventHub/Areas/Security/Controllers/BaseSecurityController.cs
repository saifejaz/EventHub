using EventHub.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventHub.Areas.Security.Controllers
{
    public class BaseSecurityController : Controller
    {
        //private EventBs objBs;
        protected SecurityBs objBs;

        public BaseSecurityController()
        {
            objBs = new SecurityBs();
        }
    }
}