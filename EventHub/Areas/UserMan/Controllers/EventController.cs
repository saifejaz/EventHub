using EventHub.BLL;
using EventHub.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventHub.Areas.UserMan.Controllers
{
    [Authorize(Roles = "A,U")]
    public class EventController :Controller
    {
        //private Event tempEvent;
        private Invitation tempInvitation;

        private UserBs objUserBs;
        private EventBs objEventBs;
        private InvitationBs objInvitationBs;

        // constructor to initialize business layer classes
        public EventController()
        {
            //tempEvent = new Event();
            tempInvitation = new Invitation();

            objUserBs = new UserBs();
            objEventBs = new EventBs();
            objInvitationBs = new InvitationBs();
        }

        // controller to create an event
        public ActionResult Index()
        {
            ViewBag.UserID = new SelectList(objUserBs.GetALL().ToList(), "UserID", "Email");
            return View();
        }

        // controller to post event data to database
        [HttpPost]
        public ActionResult Create(Event tempEvent)
        {
            // by this Linqquery i can access all the data created by the login user
            tempEvent.UserID = objUserBs.GetALL().Where(x=>x.Email==User.Identity.Name).FirstOrDefault().UserID;
            objEventBs.Insert(tempEvent);
            // if event is private and there is at least one email
            if (tempEvent.SendInvitationTo != null)
            {
                List<string> emailData = new List<string>();
                var myList = tempEvent.SendInvitationTo.Split(',').ToList();
                foreach(string result in myList)
                {
                    if(objUserBs.GetByEmail(result) != null)
                    {
                        emailData.Add(result);
                    }

                }

                //according to the divided email we count the emails and record is save according 
                //to the count of email
                foreach(string emailTo in emailData)
                {
                    tempInvitation.EventID = tempEvent.EventID;
                    tempInvitation.Email = emailTo;
                    objInvitationBs.Insert(tempInvitation);
                }
            }

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

        //to show the invitations recieved from other users
        public ActionResult EventsIAmInvitedTo()
        {
            //get all invite where  youe email is stored in database
            var tempData = objInvitationBs.GetALL().Where(x=>x.Email==User.Identity.Name);
            List<Event> getEvent= new List<Event>();
            foreach(var output in tempData)
            {
                getEvent.Add(objEventBs.GetByID(output.EventID));
            }
            return View(getEvent);
        }

        // to check how many event is created by you and sort according to date creation
        public ActionResult MyEvents()
        {
            var output = objEventBs.GetALL().Where(x => x.UserID == objUserBs.GetByEmail(User.Identity.Name).UserID);
            return View(output);
        }

        // Edit the Event
        public ActionResult Edit(int id)
        {
            var events = objEventBs.GetByID(id);
            return View(events);
        }

        [HttpPost]
        public ActionResult Edit(Event tempEvent)
        {
            if (ModelState.IsValid)
            {
                objEventBs.Update(tempEvent);
                TempData["Msg"] = "Edited Successfully";
                return RedirectToAction("Index");
            }
            return View("Index");
        }

        // Details of the Event
        public ActionResult Details(int id)
        {
            var events = objEventBs.GetByID(id);
            if (events == null)
            {
                return HttpNotFound();
            }
            return View(events);
        }

        // Delete the Event
        public ActionResult Delete(int id)
        {
            var events = objEventBs.GetByID(id);
            return View(events);
        }

        [HttpPost]
        public ActionResult Delete(int id, bool saveChangesError = false)
        {
            try
            {
                objEventBs.Delete(id);
                TempData["Msg"] = "Deleted Successfully";
            }
            catch (DataException dex)
            {
                TempData["Msg"] = "Deletion Failed : " + dex.Message;
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }
    }
}