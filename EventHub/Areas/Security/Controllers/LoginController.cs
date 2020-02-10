using EventHub.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EventHub.Areas.Security.Controllers
{
    [AllowAnonymous]
    public class LoginController : BaseSecurityController
    {
        // GET: Security/Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(EventHub.DAL.User testUser)
        {
            try
            {
                // if user email and pwd matches
                if (Membership.ValidateUser(testUser.Email, testUser.Password))
                {
                    FormsAuthentication.SetAuthCookie(testUser.Email, false);
                    return RedirectToAction("Index", "Home", new { area = "Common" });
                }
                else
                {
                    TempData["Msg"] = "Login Failed : ";
                    return RedirectToAction("Index");
                }
            }
            catch(Exception e)
            {
                TempData["Msg"] = "Login Failed : "+e.Message;
                return RedirectToAction("Index");
            }
        }

        [Authorize(Roles = "A,U")]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home", new { area = "Common" });
        }
    }
}