using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment_2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            string karan = "This is me!"; 
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            int suraj = 10;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}