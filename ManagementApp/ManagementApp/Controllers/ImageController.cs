using ManagementApp.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManagementApp.Controllers
{
    public class ImageController : Controller
    {
        ManagementContext Db = new ManagementContext();
        public ActionResult Index()
        {
            var images = Db.Images.ToList();
            return View(images);
        }
       
        // GET: Image
        public ActionResult Upload()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Upload(Image image,HttpPostedFileBase ImagePath)
        {
            Image img = new Image();
            img.ImageName = image.ImageName;
            img.ImagePath = ImagePath.FileName.ToString();

            var path = Server.MapPath("~/Content/UserImage");
            ImagePath.SaveAs(Path.Combine(path, ImagePath.FileName.ToString()));
            Db.Images.Add(img);
            Db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}