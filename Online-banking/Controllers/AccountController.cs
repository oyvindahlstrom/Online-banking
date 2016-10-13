using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_banking.Models;

namespace Online_banking.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Account(ModelContext.User inUser)
        {
            if(Session["loggedIn"] != null)
            {
                if (!(bool)Session["loggedIn"])
                {
                    RedirectToAction("index");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                Session["loggedIn"] = false;
                RedirectToAction("index");
            }
            return View();
        }
    }
}