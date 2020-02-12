using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventHub.DAL;

namespace EventHub.Areas.Security.Controllers
{
    [AllowAnonymous]
    public class RegisterController : BaseSecurityController
    {
        // GET: Security/Register
        public ActionResult Index()
        {
            return View("Index");
        }

        // method to register a new user
        [HttpPost]
        public ActionResult Create(EventHub.DAL.User tempUser)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    tempUser.Role = "U";
                    objBs.userBs.Insert(tempUser);
                    TempData["Msg"] = "Created Successfully";
                    return RedirectToAction("index");
                }
                else
                {
                    return View("index");
                }
            }
            catch(Exception e)
            {
                TempData["Msg"] = "Creation Failed : " + e.Message;
                return RedirectToAction("index");
            }
        }
    }
}