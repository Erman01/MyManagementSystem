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
    public class PersonnelController : Controller
    {
        ManagementContext Db = new ManagementContext();
        // GET: Personnel
        public ActionResult Index()
        {
            var model = Db.Personnels.Include(x => x.Department).ToList();
            return View(model);
        }
        [Authorize(Roles ="A")]
        [HttpGet]
        public ActionResult New()
        {
            var model = new PersonnelFormViewModel()
            {

                Departments = Db.Departments.ToList(),
                Personnel=new Personnel()

            };
            return View("PersonnelForm", model);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Save(Personnel personnel)
        {
            if (!ModelState.IsValid)
            {
                var model = new PersonnelFormViewModel()
                {
                    Departments = Db.Departments.ToList(),
                    Personnel = personnel
                };
                return View("PersonnelForm",model);
            }
            if (personnel.Id == 0)
            {
                Db.Personnels.Add(personnel);
            }
            else
            {
                Db.Entry(personnel).State = EntityState.Modified;
            }
            Db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Update(int id)
        {
            var model = new PersonnelFormViewModel()
            {
                Departments = Db.Departments.ToList(),
                Personnel = Db.Personnels.Find(id)
            };
            if (model==null)
            {
                return HttpNotFound();
            }
            return View("PersonnelForm", model);

        }
        public ActionResult Delete(int id)
        {
            var model = Db.Personnels.Find(id);
            if (model==null)
            {
                return HttpNotFound();
            }
            Db.Personnels.Remove(model);
            Db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}