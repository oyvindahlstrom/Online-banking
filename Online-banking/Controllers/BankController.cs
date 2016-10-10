using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online_banking.Controllers
{
    public class BankController : Controller
    {
        // GET: Bank
        public ActionResult Index()
        {
            var db = new DB();
            db.initialize_test_data();
            return View();
        }

        public ActionResult logIn()
        {
            return View();
        }
        [HttpPost]
        public  ActionResult logIn(string personalIdentification, string password)
        {
            var db = new DB();
            var checkLogIn = db.logIn(personalIdentification, password);
            if (checkLogIn)
            {
                return Index();
            }else
            {
                return View();
            }
        }
    }
}