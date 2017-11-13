using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment_2.Helpers;

namespace Assignment_2.Controllers
{
    public class QuizController : Controller
    {
        private string QuizID = "1112feeb-2b62-4031-b208-3d1f54178bda";

        // GET: Quiz
        [Authorize(Roles = "Student,Teacher,Admin")]
        [HttpGet]
        public ActionResult QuizOne()
        {
            return View();
        }

        [Authorize(Roles = "Student,Teacher,Admin")]
        [HttpPost]
        public ActionResult ProcessResult(string Answer, string js, bool chk, bool chk1, bool chk2,string tag,string tag1,string tag2,string q7,string q8,string q9,string q10)
        {

            int n = 0;
            ViewBag.answer = Answer;
            if (ViewBag.answer == "True")
            {
                ViewBag.question2 = "Correct";
                n = n + 1;
            }

            ViewBag.q2 = js;
            if (ViewBag.q2 == "True")
            {
                n = n + 1;
            }
            ViewBag.q3 = chk;
            ViewBag.q4 = chk1;
            ViewBag.q5 = chk2;
            if (ViewBag.q3 == true && ViewBag.q4 == true && ViewBag.q5 != true)
            {
                n = n + 1;
            }
            ViewBag.tag = tag;
            if(ViewBag.tag == "True")
            {
                n = n + 1;
            }
            ViewBag.tag1 = tag1;
            if(ViewBag.tag1 == "True")
            {
                n = n + 1;
            }
            ViewBag.tag2 = tag2;
            if (ViewBag.tag2 == "True")
            {
                n = n + 1;
            }
            ViewBag.q7 = q7;
            if(ViewBag.q7 == "True")
            {
                n = n + 1;
            }
            ViewBag.q8 = q8;
            if (ViewBag.q8 == "True")
            {
                n = n + 1;
            }
            ViewBag.q9 = q9;
            if (ViewBag.q9 == "True")
            {
                n = n + 1;
            }
            ViewBag.q10 = q10;
            if (ViewBag.q10 == "True")
            {
                n = n + 1;
            }

            n = n * 10;
            var help = new StudentHelpers();
            help.SaveQuizResult(n,10);

            ViewBag.result = n*10;
            ViewBag.color = "StyleSheet1.css";
            return View();
        }
    }
}