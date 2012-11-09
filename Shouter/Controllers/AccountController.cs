using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Shouter.Models;

namespace Shouter.Controllers
{
    public class AccountController : Controller
    {

        //
        // GET: /Account/LogOn

        public ActionResult LogOn()
        {
            return View();
        }

        //
        // POST: /Account/LogOn

        [HttpPost]
        public ActionResult LogOn(string email, string password)
        {
            if (Models.LogOnModel.CanLogin(email, password))
            {
                Session["email"] = email;
                return RedirectToAction("Index", "Comments");
            }
            return View();
        }
    }
}
