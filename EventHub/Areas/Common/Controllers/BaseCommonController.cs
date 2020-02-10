using EventHub.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventHub.Areas.Common.Controllers
{
    public class BaseCommonController : Controller
    {
        //private EventBs objBs;
        protected CommonBs objBs;

        public BaseCommonController()
        {
            objBs = new CommonBs();
        }
    }
}