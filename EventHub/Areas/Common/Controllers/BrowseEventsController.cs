using EventHub.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventHub.Areas.Common.Controllers
{
    [AllowAnonymous]
    public class BrowseEventsController : BaseCommonController
    {
        // GET: Common/BrowseEvents
        public ActionResult Index(string SortOrder, string SortBy)
        {
            ViewBag.SortOrder = SortOrder;
            ViewBag.SortBy = SortBy;
            var events = objBs.eventBs.GetALL();
            //var events = objBs.GetALL().Where(x => x.Type == "Private").ToList();
            switch(SortOrder)
            {
                case "Asc": events = events.OrderBy(x => x.Title).ToList();
                    break;

                case "Desc":
                    events = events.OrderByDescending(x => x.Title).ToList();
                    break;

                default: break;
            }
            return View(events);
        }
    }
}