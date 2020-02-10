using EventHub.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventHub.Areas.UserMan.Controllers
{
    [Authorize(Roles = "A,U")]
    public class EventController : Controller
    {
        private UserBs objUserBs;
        private EventBs objEventBs;

        public EventController()
        {
            objUserBs = new UserBs();
            objEventBs = new EventBs();
        }

        // GET: UserMan/Event
        public ActionResult Index()
        {
            ViewBag.UserID = new SelectList(objUserBs.GetALL().ToList(), "UserID", "Email");
            return View();
        }

        [HttpPost]
        public ActionResult Create(EventHub.DAL.Event tempEvent)
        {
            tempEvent.UserID = objUserBs.GetALL().Where(x=>x.Email==User.Identity.Name).FirstOrDefault().UserID;
            try
            {
                if (ModelState.IsValid)
                {
                    objEventBs.Insert(tempEvent);
                    TempData["Msg"] = "Created Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.UserID = new SelectList(objUserBs.GetALL().ToList(), "UserID", "Email");
                    return View("index");
                }
            }
            catch (DataException dex)
            {
                TempData["Msg"] = "Creation Failed : " + dex.Message;
                return RedirectToAction("Index");
            }
        }
    }
}