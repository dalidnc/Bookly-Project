using BooklyProject.Context;
using BooklyProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BooklyProject.Controllers
{
    public class AdminLayoutController : Controller
    {
        BooklyContext context = new BooklyContext();
        // GET: AdminLayout
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AdminLayoutNavbar()
        {
            var userName = Session["currentUser"].ToString();
            var nameSurname = context.Admins.Where(x => x.UserName == userName)
                               .Select(x => x.FirstName + " " + x.LastName)
                               .FirstOrDefault();
            ViewBag.nameSurname = nameSurname;

            var imageUrl = context.Admins.Where(x=>x.UserName==userName).Select(x => x.ImageUrl).FirstOrDefault();
            return PartialView();
        }
    }
       
}