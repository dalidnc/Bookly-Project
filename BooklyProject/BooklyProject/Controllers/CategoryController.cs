using BooklyProject.Context;
using BooklyProject.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BooklyProject.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
       
       BooklyContext context = new BooklyContext();


        public ActionResult Index()
        {
            var value = context.Categories.ToList();
            return View(value);


            return View();
        }
        public ActionResult DeleteCategory(int id) 
        {
                var value = context.Categories.Find(id);
                context.Categories.Remove(value);
                context.SaveChanges();
                return View();

        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]

        public ActionResult AddCategory(Category model)
        {
            context.Categories.Add(model);
            context.SaveChanges();
            return View();
        }
        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var value = context.Categories.Find(id);
           return View(value);
        }
        [HttpPost]
        public ActionResult UpdateCategory(Category model)
        {
            var value = context.Categories.Find(model.CategoryId);
            value.CategoryName=model.CategoryName;
            value.ImageUrl=model.ImageUrl;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}