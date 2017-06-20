using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceSub.Models;

namespace ServiceSub.Controllers
{
    [Authorize]
    public class AdministratorController : Controller
    {
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }       
    }
}