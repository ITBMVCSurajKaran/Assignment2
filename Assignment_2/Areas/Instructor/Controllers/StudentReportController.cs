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
        public ActionResult StudentDetail(string id)
        {
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    AdministrationHelpers helpers = new AdministrationHelpers();
                    var _id = Guid.Parse(id);
                    var _return = helpers.Get_Student_Report(_id);
                    return View(_return);

                }

            }
            catch (Exception)
            {

                return View("Index");
            }

            return View();
        }
    }
}