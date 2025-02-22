using BooklyProject.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BooklyProject.Controllers
{
    public class DashboardController : Controller
    {
        BooklyContext context = new BooklyContext();
        public ActionResult Index()
        {
            ViewBag.bookCount = context.Book.Count();
            ViewBag.categoryCount = context.Categories.Count();
            ViewBag.authorCount = context.Authors.Count();
            ViewBag.testimonial = context.Testimonials.Count();

            ViewBag.avgPrice = context.Book.Average(x => x.Price).ToString("000.00");
            ViewBag.mostExpensiveBook = context.Book.OrderByDescending(x => x.Price).Select(x=>x.BookName).FirstOrDefault();
            ViewBag.cheapestBook = context.Book.OrderBy(x => x.Price).Select(x => x.BookName).FirstOrDefault();
            ViewBag.onSaleBookCount = context.Book.Where(x=>x.IsOnSale).Count();
            return View();
        }
        public PartialViewResult BookList()
        {
            var values = context.Book.ToList();
            return PartialView(values);
        }
    }
}