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
            return View();
        }

        [HttpPost]
        public ActionResult logIn(User user)
        {
            if (ModelState.IsValid)
            {
                if (user.ValidUser(user.personal_Identification, user.password))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Login data is incorrect!");
                }
            }

            return View(user);
        }
    }
}