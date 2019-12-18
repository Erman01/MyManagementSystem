using ManagementApp.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ManagementApp.Controllers
{
    [AllowAnonymous]
    public class SecurityController : Controller
    {
        ManagementContext db = new ManagementContext();
        // GET: Security
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            User usr = new User();
            var userInDb = db.Users.FirstOrDefault(x => x.Name == user.Name && x.Password == user.Password);
            if (userInDb!=null)
            {
                FormsAuthentication.SetAuthCookie(user.Name, false);
                return RedirectToAction("Index", "MyCV");

            }
            else
            {
               
                if (usr.Password != user.Password)
                {
                    ViewBag.Message = "Password is incorrect please type your password correctly";
                    return View();

                }

            }
            return View();

        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}