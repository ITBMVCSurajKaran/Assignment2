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
        private string CourseId = "3E851245-056E-40BA-8767-5C662F0D0C86";
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
            if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {
                StudentHelpers sp = new StudentHelpers();
                var upa = sp.Update_Student_Course_Activity(Guid.Parse(CourseId));
            }
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
            _return.StudentPreferenceMaster = helpers.UserPrefrence(x.ToString());
            return View(_return);


        }
        public ActionResult InfoUpdate(string user, string email, int number)
        {

            var x = User.Identity.GetUserId();
            var help = new StudentHelpers();
            help.UpdateUser(user, email, number, x.ToString());
            ViewBag.name = user;
            ViewBag.email = email;
            ViewBag.number = number;

            return View("Index");

        }

        [HttpPost]
        public ActionResult BackGround(string id)
        {
            var y = User.Identity.GetUserId();
            var help = new StudentHelpers();
            var _return = help.SaveUserPreff(id);

            return View("Index");
        }
        [Authorize]
        public ActionResult Record()
        {           
            StudentHelpers helpers = new StudentHelpers();
            var x = User.Identity.GetUserId();
           StudentViewModel _return = new StudentViewModel();
            var _reg = helpers.Add_Student_Course();
            _return = helpers.Get_All_data_Student();
            _return.Get_All_Groups = helpers.Get_All_Groups();
            _return.StudentDetailModel = helpers.get_Student_ById(x.ToString());

            return View(_return);

        }
        [HttpPost]
        public ActionResult Record(Guid groupID)
        {
            var id = groupID;
            StudentHelpers helpers = new StudentHelpers();
            helpers.JoinStudentGroup(id);

            return RedirectToAction("MyProfile");
        }

    }
}
