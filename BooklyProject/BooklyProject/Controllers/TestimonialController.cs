using BooklyProject.Context;
using BooklyProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BooklyProject.Controllers
{
    public class TestimonialController : Controller
    {
        // GET: Testimonial

        BooklyContext context = new BooklyContext();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ToList()
        {
            var TestimonialToList = context.Testimonials.ToList();
            return View(TestimonialToList);
        }
        [HttpGet]
        public ActionResult UpdateTestimonial(int id)
        {
            var value = context.Testimonials.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateTestimonial(Testimonial testimonial)
        {
           var value = context.Testimonials.Find(testimonial.TestimonialId);
            value.Name = testimonial.Name;
            value.Review = testimonial.Review;
            value.Comment = testimonial.Comment;
            context.SaveChanges();
            return RedirectToAction("ToList");
        }
        [HttpGet]
        public ActionResult AddTestimonial()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddTestimonial(Testimonial testimonial)
        {
            context.Testimonials.Add(testimonial);
            context.SaveChanges();
            return RedirectToAction("ToList");
        }
     
        public ActionResult Delete(int id)
        {
            var deleteTestimonial=  context.Testimonials.Find(id);
            context.Testimonials.Remove(deleteTestimonial);
            context.SaveChanges();
            return RedirectToAction("ToList");
        }

    }
}