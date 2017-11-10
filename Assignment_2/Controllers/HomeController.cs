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

            string karan = "Last change by suraj/karan"; 
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            // this testing git push by suraj patel
           // int suraj = 10;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Test()
        {
            ViewBag.Message = " Tesing Pages!";

            return View();
        }
        public ActionResult Editor()
        {
            return View();
        }
        public ActionResult Content()
        {
            return View();
        }
        public ActionResult MyProfile()
        {
            return View();
        }
       

    }
}