using Online_banking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online_banking.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult logIn()
        {
            if(Session["loginApproved"] == null)
            {
                Session["loginApproved"] = false;
                ViewBag.loginApproved = false;
            }
            else
            {
                ViewBag.loginApproved = (bool)Session["loginApproved"];
            }
            return View();
        }

        [HttpPost]
        public ActionResult logIn(User user)
        {
            if (ModelState.IsValid)
            {
                if (Security.Validate_User(user))
                {
                    Session["loginApproved"] = true;
                    return RedirectToAction("LoginSuccessfull");
                }
                else
                {
                    Session["loginApproved"] = false;
                    ViewBag.loginApproved = false;
                    ModelState.AddModelError("", "Login data is incorrect!");
                }
            }

            return View(user);
        }

        public ActionResult LoginSuccessfull()
        {
            if(Session["loginApproved"] != null)
            {
                bool isLoggedIn = (bool)Session["loginApproved"];
                if(isLoggedIn)
                {
                    ViewBag.loginApproved = true;
                    return View();
                }
            }
            return RedirectToAction("LogIn");
        }
    }
}