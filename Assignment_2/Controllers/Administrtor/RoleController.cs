using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment_2.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Assignment_2.Controllers.Administrtor
{
    public class RoleController : Controller
    {
         ApplicationDbContext context;
        public RoleController()
        {
            context = new ApplicationDbContext();
        }

        // GET: Role
        [Authorize(Roles ="Admin")]
        public ActionResult Index()
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
        public ActionResult Create()
        {
            var Role = new IdentityRole();
            return View(Role);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(IdentityRole Role)
        {
            context.Roles.Add(Role);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}