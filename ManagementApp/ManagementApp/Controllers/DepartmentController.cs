using ManagementApp.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManagementApp.Controllers
{
    public class DepartmentController : Controller
    {
        ManagementContext Db = new ManagementContext();
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
            }
            else
            {
                Db.Entry(department).State = EntityState.Modified;
            }
            Db.SaveChanges();
            return RedirectToAction("Index");
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