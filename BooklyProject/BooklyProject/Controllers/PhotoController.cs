using BooklyProject.Context;
using BooklyProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BooklyProject.Controllers
{
    public class PhotoController : Controller
    {
        BooklyContext context = new BooklyContext();
        // GET: Photo
        [HttpGet]
        public ActionResult Index()
        {
          return View();
        }
        public ActionResult ListPhoto()
        {
            var photoGalleries = context.PhotoGalleries.ToList();  // Veriyi al
            return View(photoGalleries);

        }
        [HttpGet]
        public ActionResult AddPhoto()
        {
           
            return View();

        }
        [HttpPost]
        public ActionResult AddPhoto(PhotoGallery photo)
        {
            context.PhotoGalleries.Add(photo);
            context.SaveChanges();
            return View("ListPhoto");
        }
        [HttpGet]
        public ActionResult UpdatePhoto(int id)
        {
            var value = context.PhotoGalleries.Find(id);
            return View(value);
         

        }
        [HttpPost]
        public ActionResult UpdatePhoto(PhotoGallery photo)
        {
            var value = context.PhotoGalleries.Find(photo.PhotoGalleryId);
            if (value == null)
            {
                return HttpNotFound(); // Eğer kayıt bulunamazsa 404 döndür
            }
            value.ImageUrl = photo.ImageUrl;
            value.IsShown = photo.IsShown;
            context.SaveChanges();
            return RedirectToAction("ListPhoto");
        }
        public ActionResult DeletePhoto(int id)
        {
            var deleteId = context.PhotoGalleries.Find(id);
            context.PhotoGalleries.Remove(deleteId);
            context.SaveChanges();
            return View();

        }
    }
}