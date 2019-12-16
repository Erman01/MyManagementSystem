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
            var userInDb = db.Users.FirstOrDefault(x => x.Name == user.Name && x.Password == user.Password);
            if (userInDb!=null)
            {
                FormsAuthentication.SetAuthCookie(userInDb.Name,false);
                return RedirectToAction("Index","Department");
            }
            else
            {
               
                ViewBag.Message = "Username or Password is incorrect";
                return View();
            }
            
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}