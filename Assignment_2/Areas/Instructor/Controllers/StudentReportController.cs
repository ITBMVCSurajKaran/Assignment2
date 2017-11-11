using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment_2.Helpers;

namespace Assignment_2.Areas.Instructor.Controllers
{
    public class StudentReportController : Controller
    {
        private MyLearnDBEntities db = new MyLearnDBEntities();

        // GET: Instructor/StudentReport
        public ActionResult Index()
        {
            
            return View(db.GroupMasters.ToList());
        }
    }
}