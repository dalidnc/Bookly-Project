using BooklyProject.Context;
using BooklyProject.Entities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BooklyProject.Controllers
{
    public class BookController : Controller
    {
        // GET: Book,
        BooklyContext context=new BooklyContext();

        [HttpGet]
        public ActionResult Index(string searchText)
        {
            List<Book> values;
            if(searchText!= null)
            {
                 values = context.Book.Where(x=>x.BookName.Contains(searchText)).ToList();
                return View(values);
            }

            values = context.Book.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddBook()
        {
            return View();
        }
        [HttpPost]
       
        public ActionResult AddBook(Book model, string AuthorName,string AuthorSurname)
        {
            var author = context.Authors.FirstOrDefault(a => a.Name == AuthorName & a.Surname == AuthorSurname);


            if (author == null)
                {
                author = new Author { Name = AuthorName, Surname = AuthorSurname };
                context.Authors.Add(author);
                    context.SaveChanges(); 
                }

                model.AuthorId = author.AuthorId; 

               
                context.Book.Add(model);
                context.SaveChanges();

                return RedirectToAction("Index"); 
        }
        [HttpGet]
        public ActionResult UpdateBook(int id)
        {
            var value = context.Book.Find(id);
          

            
           

            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateBook(Book book,Author author1)
        {
            var value = context.Book.Find(book.BookId);  
           
            value.BookName = book.BookName;
            value.CoverImageUrl = book.CoverImageUrl;
            value.Review = book.Review;
            
           var author = context.Authors.Find(value.AuthorId);
            author.Name = author1.Name;
            author.Surname = author1.Surname;



            context.SaveChanges();


            return RedirectToAction("Index");


        }
        public ActionResult DeleteBook(int id)
        {

            var value = context.Book.Find(id);
            context.Book.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");

        } 
        public ActionResult cheapestBooks()
        {
            List<Book> values;
            values = context.Book.OrderBy(x=>x.Price).ToList();
            return View(values);


        }
        public ActionResult expensiveBooks()
        {
            List<Book> values;
            values = context.Book.OrderByDescending(x => x.Price).ToList();
            return View(values);


        }
        public ActionResult isOnSaleBooks()
        {
            List<Book> values;
            values = context.Book .Where(x => x.IsOnSale).OrderByDescending(x => x.DiscountRate).ToList();
            return View(values);


        }




    }
}
