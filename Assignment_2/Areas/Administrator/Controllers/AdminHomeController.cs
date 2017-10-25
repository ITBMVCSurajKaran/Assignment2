using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment_2.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Assignment_2.Areas.Administrator.Controllers
{
    public class AdminHomeController : Controller
    {
        
        ApplicationDbContext context;

        public AdminHomeController()
        {
            context = new ApplicationDbContext();
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



        // GET: Role
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
        [Authorize(Roles = "Admin")]
        public ActionResult AddRole()
        {
            var Role = new IdentityRole();
            return View(Role);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult AddRole(IdentityRole Role)
        {
            context.Roles.Add(Role);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion
    }
}