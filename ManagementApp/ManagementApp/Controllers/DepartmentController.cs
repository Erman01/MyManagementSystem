using ManagementApp.Models.EntityFramework;
using ManagementApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManagementApp.Controllers
{
    [Authorize(Roles = "A,B")] //Only role A and B can see here and Manipulate it
    public class DepartmentController : Controller
    {
        ManagementContext Db = new ManagementContext();
        MessageViewModel msg = new MessageViewModel();
        // GET: Department
        public ActionResult Index()
        {
            
            return View(Db.Departments.ToList());
        }

        [HttpGet]
        public ActionResult New()
        {
            return View("DepartmentForm",new Department());
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Save(Department department)
        {
            if (!ModelState.IsValid)
            {
                return View("DepartmentForm");
            }
            
            if (department.Id==0)
            {
                Db.Departments.Add(department);
                msg.Message = department.DepartmentName + " Added successfully";
            }
            else
            {
                Db.Entry(department).State = EntityState.Modified;
                msg.Message = department.DepartmentName + " Updated successfully";
            }
           
            Db.SaveChanges();
            msg.Status = true;
            msg.LinkText = "Back to Department List";
            msg.Url = "/Department";
            return View("_Message",msg);
        }
        public ActionResult Update(int id)
        {
            var model = Db.Departments.Find(id);
            if (model==null)
            {
                return HttpNotFound();
            }
            return View("DepartmentForm",model);
        }
        public ActionResult Delete(int id)
        {
            var model = Db.Departments.Find(id);
            if (model==null)
            {
                return HttpNotFound();
            }
            Db.Departments.Remove(model);
            Db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}