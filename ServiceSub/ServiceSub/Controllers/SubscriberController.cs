using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceSub.Models;

namespace ServiceSub.Controllers
{
    public class SubscriberController : Controller
    {
        private SubscriptionContext _db = new SubscriptionContext();

        public ActionResult Index()
        {
            ViewBag.Message = "Witam Cie w serwisie Subskrybcji";
            return View();
        }

        public SubscriberController()
        {
            _db = new SubscriptionContext();
        }

        public ActionResult List()
        {
            //download list of subscribers and show them to users
            var subscribers = _db.Subscribers;
            return View(subscribers);
        }

        public ActionResult Subscribe()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Subscribe(Subscriber model)
        {
            //watch if model is correct
            if(ModelState.IsValid)
            {
                try
                {
                    var subscriber = _db.Subscribers.FirstOrDefault(u => u.Email.Equals(model.Email));

                    if (subscriber == null)
                    {
                        subscriber = model;
                        subscriber.RegistrationDate = DateTime.Now;

                        _db.Subscribers.Add(subscriber);
                        _db.SaveChanges();
                    }
                    else
                    {
                        TempData["Error"] = "Taki adres email juz jest zarejestrowany.";
                        return View(model);
                    }
                }
                catch
                {
                    TempData["Error"] = "Coś jest nie tak";
                    return View();
                }

                TempData["Message"] = "Adres email został zapisany.";
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult Unsubscribe()
        {
            return View();       
        }

        [HttpPost]
        public ActionResult Unsubscribe(Subscriber model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var subscriber = _db.Subscribers.FirstOrDefault(u => u.Surname.Equals(model.Surname));

                    if (subscriber != null)
                    {
                        _db.Subscribers.Remove(subscriber);
                        _db.SaveChanges();
                    }
                    else
                    {
                        TempData["Error"] = "Subskrypcja o takich danych nie istnieje. Popraw je.";
                        return View(model);
                    }
                }
                catch
                {
                    TempData["Error"] = "Coś jest nie tak";
                    return View();
                }
                TempData["Message"] = "Pomyslnie usunieto subskrypcje";
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }
       


    }
}