using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartShareV2.Controllers
{
    public class AboutController : Controller
    {
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
