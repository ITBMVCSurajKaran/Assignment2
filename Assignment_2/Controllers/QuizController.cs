using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment_2.Controllers
{
    public class QuizController : Controller
    {
        // GET: Quiz
        //[Authorize(Roles ="user")]
        [HttpGet]
        public ActionResult QuizOne()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ProcessResult(string Answer, string js, bool chk, bool chk1, bool chk2,string tag,string tag1,string tag2)
        {

            var n = 0;
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


            ViewBag.result = n;
            
          

            return View();
        }
    }
}