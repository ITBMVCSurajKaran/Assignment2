using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Assignment_2.Models;
using Assignment_2.Helpers;

namespace Assignment_2.Controllers
{   [Authorize]
    public class JavascriptBeginnerController : Controller
    {
        // GET: JavascriptBeginner
        public ActionResult Index()
        {
            var x = User.Identity.GetUserId();

            StudentViewModel _return = new StudentViewModel();
            StudentHelpers helpers = new StudentHelpers();
            _return = helpers.Get_All_data_Student();
            _return.StudentDetailModel = helpers.get_Student_ById(x.ToString());

            return View(_return);
        }
        public ActionResult Chapter1()
        {
            return View();
        }
        public ActionResult Chapter2()
        {
            return View();
        }

        public ActionResult Chapter3()
        {
            return View();
        }

        public ActionResult Chapter4()
        {
            return View();
        }

        public ActionResult Chapter5()
        {
            return View();
        }

        public ActionResult Chapter6()
        {
            return View();
        }

        public ActionResult Chapter7()
        {
            return View();
        }


        public ActionResult Chapter8()
        {
            return View();
        }


        public ActionResult Chapter9()
        {
            return View();
        }


        public ActionResult Chapter10()
        {
            return View();
        }
    }
}