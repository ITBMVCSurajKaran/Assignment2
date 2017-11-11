using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Assignment_2.Models;
using Assignment_2.Helpers;

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

        [Authorize]
        public ActionResult MyProfile()
        {
            var x = User.Identity.GetUserId() ;

            StudentDetailModel _return = new StudentDetailModel();
            StudentHelpers helpers = new StudentHelpers();

            _return = helpers.get_Student_ById(x.ToString());
              
            return View(_return);
        }
       

    }
}