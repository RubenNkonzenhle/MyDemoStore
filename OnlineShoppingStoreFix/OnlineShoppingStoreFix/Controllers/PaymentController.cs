using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingStoreFix.Controllers
{
    public class PaymentController : Controller
    {
         // GET: Payment
       public ActionResult SuccessView()
        {
            return View();
        }
    }
}