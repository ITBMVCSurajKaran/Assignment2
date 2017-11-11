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
            
            StudentHelpers helpers = new StudentHelpers();
            var _return = helpers.Get_announcemnets();
            return View(_return);

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
        [ValidateInput(false)]
        public ActionResult Editor(string editorValue)
        {
            ViewBag.editorValue = editorValue;
            return View();
        }
        public ActionResult Content()
        {
            return View();
        }

        [Authorize]
        public ActionResult MyProfile()
        {
            var x = User.Identity.GetUserId();

            StudentViewModel _return = new StudentViewModel();
            StudentHelpers helpers = new StudentHelpers();
            _return = helpers.Get_All_data_Student();
            _return.StudentDetailModel = helpers.get_Student_ById(x.ToString());

            return View(_return);
            

        }


    }
}