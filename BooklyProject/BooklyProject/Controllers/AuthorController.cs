using BooklyProject.Context;
using BooklyProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BooklyProject.Controllers
{
    public class AuthorController : Controller
    {
        BooklyContext context = new BooklyContext();
        // GET: Author
        public ActionResult Index(string searchText)
        {
            return View();
           
          
        }
        [HttpGet]
        public ActionResult AddAuthor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAuthor(Author author)
        {
            context.Authors.Add(author);
            context.SaveChanges();
            return View();
        }
        public ActionResult AuthorList(string searchText)
        {
            List<Author> values;
            
           
            if (searchText != null)
            {
                values = context.Authors.Where(x => x.Name.Contains(searchText)).ToList();
                return View(values);
            }

            values = context.Authors.ToList();
            return View(values);
            
           
        }
        public ActionResult DeleteAuthor(int id)
        {
            var deleteId=context.Authors.Find(id);
            context.Authors.Remove(deleteId);
            context.SaveChanges();
            return View();

        }
        [HttpGet]
        public ActionResult UpdateAuthor(int id)
        {
            var value = context.Authors.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateAuthor(Author author)
        {
            var value = context.Authors.Find(author.AuthorId);
            value.Name = author.Name;
            value.Surname = author.Surname;
            context.SaveChanges();
            return RedirectToAction("AuthorList");
          
        }

    }
}