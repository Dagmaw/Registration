using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Registration.WebAPI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Registration()
        {
            return View();
        }
    }
}