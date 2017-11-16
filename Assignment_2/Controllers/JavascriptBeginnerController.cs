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
    [Authorize]
    public class JavascriptBeginnerController : Controller
    {
        private string CourseId = "3E851245-056E-40BA-8767-5C662F0D0C86";
        // GET: JavascriptBeginner
        //public ActionResult Index()
        //{
        //    var x = User.Identity.GetUserId();

        //    StudentViewModel _return = new StudentViewModel();
        //    StudentHelpers helpers = new StudentHelpers();
        //    _return = helpers.Get_All_data_Student();
        //    _return.StudentDetailModel = helpers.get_Student_ById(x.ToString());

        //    return View(_return);
        //}
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
            StudentHelpers helper = new StudentHelpers();
            helper.Update_Student_Course_Status(Guid.Parse(CourseId), 30);
            return View();
        }

        public ActionResult Chapter4()
        {
            StudentHelpers helper = new StudentHelpers();
            helper.Update_Student_Course_Status(Guid.Parse(CourseId), 40);
            return View();
        }

        public ActionResult Chapter5()
        {
            StudentHelpers helper = new StudentHelpers();
            helper.Update_Student_Course_Status(Guid.Parse(CourseId), 50);
            return View();
        }

        public ActionResult Chapter6()
        {
            StudentHelpers helper = new StudentHelpers();
            helper.Update_Student_Course_Status(Guid.Parse(CourseId), 60);
            return View();
        }

        public ActionResult Chapter7()
        {
            StudentHelpers helper = new StudentHelpers();
            helper.Update_Student_Course_Status(Guid.Parse(CourseId), 70);
            return View();
        }


        public ActionResult Chapter8()
        {
            StudentHelpers helper = new StudentHelpers();
            helper.Update_Student_Course_Status(Guid.Parse(CourseId), 80);
            return View();
        }


        public ActionResult Chapter9()
        {
            StudentHelpers helper = new StudentHelpers();
            helper.Update_Student_Course_Status(Guid.Parse(CourseId), 90);
            return View();
        }


        public ActionResult Chapter10()
        {
            StudentHelpers helper = new StudentHelpers();
            helper.Update_Student_Course_Status(Guid.Parse(CourseId), 100);
            return View();
        }
    }
}