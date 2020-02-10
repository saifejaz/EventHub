using EventHub.BLL;
using EventHub.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventHub.Areas.Admin.Controllers
{
    [Authorize(Roles ="A")]
    public class ListEventsController : BaseAdminController
    {
        // GET: Admin/ListEvents
        public ActionResult Index(string SortOrder, string SortBy)
        {
            ViewBag.SortOrder = SortOrder;
            ViewBag.SortBy = SortBy;
            var events = objBs.listEventBs.GetALL();
            //var events = objBs.GetALL().Where(x => x.Type == "Private").ToList();
            switch (SortOrder)
            {
                case "Asc":
                    events = events.OrderBy(x => x.Title).ToList();
                    break;

                case "Desc":
                    events = events.OrderByDescending(x => x.Title).ToList();
                    break;

                default: break;
            }
            return View(events);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var events = objBs.listEventBs.GetByID(id);
            return View(events);
        }

        [HttpPost]
        public ActionResult Edit(Event temp)
        {
            if (ModelState.IsValid)
            {
                objBs.listEventBs.Update(temp);
                TempData["Msg"] = "Edited Successfully";
                return RedirectToAction("Index");
            }
            return View("Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var events = objBs.listEventBs.GetByID(id);
            if (events == null)
            {
                return HttpNotFound();
            }
            return View(events);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var events = objBs.listEventBs.GetByID(id);
            return View(events);
        }

        [HttpPost]
        public ActionResult Delete(int id, bool saveChangesError = false)
        {
            try
            {
                objBs.listEventBs.Delete(id);
                TempData["Msg"] = "Deleted Successfully";
            }
            catch (DataException dex)
            {
                TempData["Msg"] = "Deletion Failed : "+dex.Message;
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }
    }
}