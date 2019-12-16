using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ManagementApp.Models.EntityFramework;

namespace ManagementApp.Controllers
{
    public class UserController : Controller
    {
        private ManagementContext db = new ManagementContext();

        // GET: User
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }
        public ActionResult ImageIndex()
        {
            return View(db.Images.ToList());
        }
        public ActionResult ImageGalleryIndex()
        {
            return View(db.ImageGalleries.ToList());
        }
        // GET: User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
        public ActionResult ImageUpload()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ImageUpload(Image userImage,HttpPostedFileBase ImageUrl)
        {
            Image img = new Image();
            img.ImageName = userImage.ImageName;
           
            img.ImagePath = ImageUrl.FileName.ToString();

            var path = Server.MapPath("~/Content/UserImage");
            ImageUrl.SaveAs(Path.Combine(path, ImageUrl.FileName.ToString()));
            db.Images.Add(img);
            db.SaveChanges();
            return RedirectToAction("ImageIndex");
        }
        public ActionResult ImageDelete(int id)
        {
            var model = db.Images.Find(id);
            if (model==null)
            {
                return HttpNotFound();
            }
            db.Images.Remove(model);
            db.SaveChanges();
            return RedirectToAction("ImageIndex");
        }
        public ActionResult GalleryImageUpload()
        {
            return View();
        }
       [HttpPost]
        public ActionResult GalleryImageUpload(ImageGallery userGalleryImage, HttpPostedFileBase GalleryImagePath)
        {
            ImageGallery imgGallery = new ImageGallery();
            imgGallery.GalleryImageName = userGalleryImage.GalleryImageName;
            imgGallery.GalleryImagePath = GalleryImagePath.FileName.ToString();

            var path = Server.MapPath("~/Content/UserGallery");
            GalleryImagePath.SaveAs(Path.Combine(path, GalleryImagePath.FileName.ToString()));
            db.ImageGalleries.Add(imgGallery);
            db.SaveChanges();
            return RedirectToAction("ImageGalleryIndex");
        }
        public ActionResult GalleryDelete(int id)
        {
            var model = db.ImageGalleries.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            db.ImageGalleries.Remove(model);
            db.SaveChanges();
            return RedirectToAction("ImageGalleryIndex");
        }
        // GET: User/Create
        [AllowAnonymous]
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Create([Bind(Include = "Id,Name,Password,Role")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Password,Role")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
