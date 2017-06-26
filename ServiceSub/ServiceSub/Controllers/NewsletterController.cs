using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceSub.Models;
using ServiceSub.Helpers;


namespace ServiceSub.Controllers
{
    public class NewsletterController : Controller
    {
        private SubscriptionContext _db = new SubscriptionContext();

        public NewsletterController()
        {
            _db = new SubscriptionContext();
        }

        public ActionResult Send()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Send(Newsletter news)
        {
            if(ModelState.IsValid)
            {
                var subscribers = _db.Subscribers;

                //create a list of subscribers
                List<string> emails = subscribers.Select(u => u.Email).ToList();

                if (emails.Count > 0)
                {
                    MailHelper.SendEmail(emails, news.Subject, news.Content);
                    return View("Sent");
                }
                else
                {
                    TempData["Error"] = "Brak aktywnych użytkowników. Email nie zostanie wysłany.";
                    return View();
                }

            }
            return View(news);
        }




    }
}