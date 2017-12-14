using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SchoolTime.DAL;
using SchoolTime.Models;

namespace SchoolTime.Controllers
{
    public class tblTeachersController : Controller
    {
        private SchoolTimeContext db = new SchoolTimeContext();

        // GET: tblTeachers
        public ActionResult Index()
        {
            var tblTeachers = db.tblTeachers.Include(t => t.tblMajor);
            return View(tblTeachers.ToList());
        }

        // GET: tblTeachers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTeacher tblTeacher = db.tblTeachers.Find(id);
            if (tblTeacher == null)
            {
                return HttpNotFound();
            }
            return View(tblTeacher);
        }

        // GET: tblTeachers/Create
        public ActionResult Create()
        {
            ViewBag.MajorID = new SelectList(db.tblMajors, "MajorID", "MajorName");
            return View();
        }

        // POST: tblTeachers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "teachID,teachCode,FullName,Education,Position,Expert,MajorID,BirthDate,Tel,Email,Remark")] tblTeacher tblTeacher)
        {
            if (ModelState.IsValid)
            {
                if (db.tblTeachers.Where(h => h.teachCode == tblTeacher.teachCode).ToList().Count > 0)
                {
                    TempData["alertMessage"] = "รหัสอาจารย์ไม่สามารถซ้ำได้";
                    ViewBag.MajorID = new SelectList(db.tblMajors, "MajorID", "MajorName", tblTeacher.MajorID);
                    return View(tblTeacher);
                }
                else
                {
                    tblTeacher.teachID = Guid.NewGuid().ToString();
                    db.tblTeachers.Add(tblTeacher);


                    //Save User
                    tblUser TempUser = new tblUser();
                    TempUser.UserID = Guid.NewGuid().ToString();
                    TempUser.UserName = tblTeacher.Email;
                    TempUser.Password = tblTeacher.BirthDate.ToString("ddMMyyyy");
                    TempUser.relateID = tblTeacher.teachID;
                    TempUser.relateTable = "tblTeacher";
                    db.tblUsers.Add(TempUser);

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            ViewBag.MajorID = new SelectList(db.tblMajors, "MajorID", "MajorName", tblTeacher.MajorID);
            return View(tblTeacher);
        }

        // GET: tblTeachers/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTeacher tblTeacher = db.tblTeachers.Find(id);
            if (tblTeacher == null)
            {
                return HttpNotFound();
            }
            ViewBag.MajorID = new SelectList(db.tblMajors, "MajorID", "MajorName", tblTeacher.MajorID);
            return View(tblTeacher);
        }

        // POST: tblTeachers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "teachID,teachCode,FullName,Education,Position,Expert,MajorID,BirthDate,Tel,Email,Remark")] tblTeacher tblTeacher)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblTeacher).State = EntityState.Modified;
                db.SaveChanges();

                string relateID = Convert.ToString(Session["relateID"]);
                string relateTable = Convert.ToString(Session["relateTable"]);
                if (relateTable == "tblTeacher")
                {
                    return RedirectToAction("Index", "Home", new { area = "" });
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            ViewBag.MajorID = new SelectList(db.tblMajors, "MajorID", "MajorName", tblTeacher.MajorID);
            return View(tblTeacher);
        }

        // GET: tblTeachers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTeacher tblTeacher = db.tblTeachers.Find(id);
            if (tblTeacher == null)
            {
                return HttpNotFound();
            }
            return View(tblTeacher);
        }

        // POST: tblTeachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tblTeacher tblTeacher = db.tblTeachers.Find(id);
            db.tblTeachers.Remove(tblTeacher);
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
