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
        public ActionResult Test_Data()
        {
            var db = new DB();
            db.initialize_test_data();
            return View();
        }
    }
}