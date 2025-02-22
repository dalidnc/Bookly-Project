using BooklyProject.Context;
using BooklyProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BooklyProject.Controllers
{
    public class MessageController : Controller
    {
        BooklyContext context = new BooklyContext();
        // GET: Message
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ListMessage(string searchText)
        {
            List<Message> values;


            if (searchText != null)
            {
                values = context.Messages.Where(x => x.Name.Contains(searchText)).ToList();
                return View(values);
            }

            values = context.Messages.ToList();
            return View(values);

        }
        [HttpGet]
        public ActionResult UpdateMessage(int id)
        {
            var value = context.Messages.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateMessage(Message message)
        {
            var values = context.Messages.Find(message.MessageId);
            values.Name = message.Name;
            values.Email = message.Email;
            values.MessageContent = message.MessageContent;
            context.SaveChanges();
            return RedirectToAction("ListMessage");
        }
        public ActionResult DeleteMessage(int id)
        {
            var values = context.Messages.Find(id);
            context.Messages.Remove(values);
            context.SaveChanges();
            return RedirectToAction("ListMessage");
        }
    }
}