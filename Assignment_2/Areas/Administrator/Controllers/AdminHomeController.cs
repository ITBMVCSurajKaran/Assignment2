using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment_2.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Assignment_2.Helpers;

namespace Assignment_2.Areas.Administrator.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminHomeController : Controller
    {

        ApplicationDbContext context;
        MyLearnDBEntities db;
        AdministrationHelpers helpers;

        public AdminHomeController()
        {
            context = new ApplicationDbContext();
            db = new MyLearnDBEntities();
            helpers = new AdministrationHelpers();
        }

        // GET: Administrator/Home
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }

        #region User Management

        /// <summary>
        /// Only admin can access/
        /// </summary>
        /// <returns>All users</returns>
        [Authorize(Roles = "Admin")]
        public ActionResult Users()
        {
            try
            {
                var users = context.Users.ToList();
                return View(users);
            }
            catch (Exception ex)
            {

                ViewBag.ErrorMessage = ex.Message;
                return View();
            }


        }

        #endregion

        #region Roles Management



        /// <summary>
        /// Get all roles
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        public ActionResult Roles()
        {
            try
            {
                var Roles = context.Roles.ToList();
                return View(Roles);

            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        /// <summary>
        /// Add new role get
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        public ActionResult AddRole()
        {
            var Role = new IdentityRole();
            return View(Role);
        }

        /// <summary>
        /// Add new role Post 
        /// </summary>
        /// <param name="Role"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult AddRole(IdentityRole Role)
        {
            try
            {
                if (!string.IsNullOrEmpty(Role.Name))
                {
                    context.Roles.Add(Role);
                    context.SaveChanges();
                    return RedirectToAction("Roles");
                }
            }
            catch (Exception)
            {


            }
            return View();


        }
        #endregion


        #region Announcements 
        /// <summary>
        /// Add new Announcement for group or Student
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Announcement()
        {
            Announcement model = new Assignment_2.Announcement();
            model.UserType = "Student";
            return View(model);
        }

        /// <summary>
        /// Add new Announcement for group or Student
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Announcement(Announcement Model)
        {
            if (Model != null)
            {
                var _result = helpers.Add_Announcement(Model);
                if (!_result)
                {
                    ViewBag.Error = "Ok";
                    return View(Model);
                }
            }

            return View("Index");
        }
        #endregion
    }
}