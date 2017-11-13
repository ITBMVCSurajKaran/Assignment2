using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assignment_2;
using Microsoft.AspNet.Identity;

namespace Assignment_2.Areas.Administrator.Controllers
{
    [Authorize(Roles ="Admin")]
    public class GroupMastersController : Controller
    {
        private MyLearnDBEntities db = new MyLearnDBEntities();

        // GET: Administrator/GroupMasters
        public ActionResult Index()
        {
            return View(db.GroupMasters.ToList());
        }

        // GET: Administrator/GroupMasters/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupMaster groupMaster = db.GroupMasters.Find(id);
            if (groupMaster == null)
            {
                return HttpNotFound();
            }
            return View(groupMaster);
        }

        // GET: Administrator/GroupMasters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administrator/GroupMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,GroupName,CreatedBy,CourseID,CreatedDate,DateEdited,IsEnable,IsActive")] GroupMaster groupMaster)
        {
            if (groupMaster.GroupName!= "")
            {
                string userId = User.Identity.GetUserId();
                groupMaster.Id = Guid.NewGuid();
                groupMaster.CreatedBy = Guid.Parse(userId);
                groupMaster.CreatedDate = DateTime.Now;
                groupMaster.CourseID = Guid.Parse("3E851245-056E-40BA-8767-5C662F0D0C86");
                groupMaster.DateEdited = DateTime.Now;
                groupMaster.IsActive = true;
                groupMaster.IsEnable = true;

                db.GroupMasters.Add(groupMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Error = "Ok";
            return View(groupMaster);
        }

        // GET: Administrator/GroupMasters/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupMaster groupMaster = db.GroupMasters.Find(id);
            if (groupMaster == null)
            {
                return HttpNotFound();
            }
            return View(groupMaster);
        }

        // POST: Administrator/GroupMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,GroupName,CreatedBy,CourseID,CreatedDate,DateEdited,IsEnable,IsActive")] GroupMaster groupMaster)
        {
            if (ModelState.IsValid)
            {
                
                var _groupMaster = db.GroupMasters.SingleOrDefault(x => x.Id == groupMaster.Id);
                _groupMaster.DateEdited = DateTime.Now;
                _groupMaster.GroupName = groupMaster.GroupName;
                _groupMaster.IsEnable = groupMaster.IsEnable;
                 db.Entry(_groupMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Error = "Ok";
            return View(groupMaster);
        }

        // GET: Administrator/GroupMasters/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroupMaster groupMaster = db.GroupMasters.Find(id);
            if (groupMaster == null)
            {
                return HttpNotFound();
            }
            return View(groupMaster);
        }

        // POST: Administrator/GroupMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            GroupMaster groupMaster = db.GroupMasters.Find(id);
            db.GroupMasters.Remove(groupMaster);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
