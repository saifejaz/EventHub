using EventHub.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventHub.Areas.Admin.Controllers
{
    public class ListUsersController : BaseAdminController
    {
        // GET: Admin/ListUsers
        public ActionResult Index(string SortOrder, string SortBy)
        {
            ViewBag.SortOrder = SortOrder;
            ViewBag.SortBy = SortBy;
            var events = objBs.userBs.GetALL();
            //var events = objBs.GetALL().Where(x => x.Type == "Private").ToList();
            switch (SortOrder)
            {
                case "Asc":
                    events = events.OrderBy(x => x.UserName).ToList();
                    break;

                case "Desc":
                    events = events.OrderByDescending(x => x.UserName).ToList();
                    break;

                default: break;
            }
            return View(events);
        }
    }
}