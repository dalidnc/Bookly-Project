using BooklyProject.Context;
using BooklyProject.Entities;
using System.Linq;
using System.Threading;
using System.Web.Mvc;


namespace BooklyProject.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        BooklyContext context =new BooklyContext();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult DefaultCategories()
        {
            var values = context.Categories.OrderByDescending(x=>x.CategoryId).Take(6).ToList();
            return PartialView(values);
        }
        public PartialViewResult DefaultBooks()
        {
            var value = context.Book.OrderByDescending(x=>x.BookId).Take(6).ToList();
            return PartialView(value);
        }
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult SendMessage(Message model)
        {
            context.Messages.Add(model);
            context.SaveChanges();
            Thread.Sleep(2000);
            return RedirectToAction("Index");
        }


        public PartialViewResult OrderBooks()
        {
            var values = context.Book.OrderByDescending(x => x.Review).Take(3).ToList();
            ViewBag.LastAdded = context.Book.Where(x => x.IsOnSale==false).Take(3).ToList();
            ViewBag.isOnSale = context.Book.Where(x=>x.IsOnSale).Take(3).ToList();
            
            return PartialView(values);
        }

        public PartialViewResult TitleBooks()
        {
            ViewBag.mainBook = context.Book.OrderByDescending(x => x.DiscountRate).Select(x => x.BookName).FirstOrDefault();
            ViewBag.mainBookCover = context.Book.OrderByDescending(x => x.DiscountRate).Select(x => x.CoverImageUrl).FirstOrDefault();
            ViewBag.mainBook2 = context.Book.OrderByDescending(x => x.Review).Select(x => x.BookName).FirstOrDefault();
            ViewBag.mainBookCover2 = context.Book.OrderByDescending(x => x.Review).Select(x => x.CoverImageUrl).FirstOrDefault();
            return PartialView();
        }
        public PartialViewResult Gallery()
        {
            var values = context.PhotoGalleries.OrderBy(x=>x.PhotoGalleryId).Take(6).ToList();
            return PartialView(values);
        }

        public PartialViewResult TestimonialPart()
        {
            var values = context.Testimonials.OrderBy(x=>x.TestimonialId).Take(6).ToList();
            return PartialView(values);
        }
       
    }
}