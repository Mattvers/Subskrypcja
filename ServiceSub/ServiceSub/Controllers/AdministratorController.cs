using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceSub.Models;
using System.Data.Entity;

namespace ServiceSub.Controllers
{
    [Authorize]
    [AllowAnonymous]
    public class AdministratorController : Controller
    {     
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Users u)
        {
            // section for post login
            if (ModelState.IsValid)
            {
                using (ServiceSubEntities dc = new ServiceSubEntities())
                {
                    var local = dc.Users.Where(a => a.userName.Equals(u.userName) && a.password.Equals(u.password)).FirstOrDefault();

                    if (local != null)
                    {
                        Session["LogedUserID"] = local.Id.ToString();
                        Session["LogedUserFullName"] = local.FullName.ToString();
                        return RedirectToAction("AfterLogin");
                    }
                }
            }
            return View("BadLogin");
        }

        public ActionResult AfterLogin()
        {
            if (Session["LogedUserID"] != null)
            {               
                return RedirectToAction("AdminIndex");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult AdminIndex()
        {
            return View();
        }
    }
}