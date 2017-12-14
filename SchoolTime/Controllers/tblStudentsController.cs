using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using SchoolTime.DAL;
using SchoolTime.Models;

namespace SchoolTime.Controllers
{
    public class tblStudentsController : Controller
    {
        private SchoolTimeContext db = new SchoolTimeContext();

        // GET: tblStudents
        public ActionResult Index()
        {
            var tblStudents = db.tblStudents.Include(t => t.tblMinor);
            return View(tblStudents.ToList());
        }

        // GET: tblStudents/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStudent tblStudent = db.tblStudents.Find(id);
            if (tblStudent == null)
            {
                return HttpNotFound();
            }
            return View(tblStudent);
        }

        // GET: tblStudents/Create
        public ActionResult Create()
        {
            ViewBag.MinorID = new SelectList(db.tblMinors, "MinorID", "MinorName");
            return View();
        }

        // POST: tblStudents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudID,StudCode,FullName,MajorID,MinorID,Year,BirthDate,Tel,Email,Remark")] tblStudent tblStudent)
        {
            if (ModelState.IsValid)
            {
                if (db.tblStudents.Where(h => h.StudCode == tblStudent.StudCode).ToList().Count > 0)
                {
                    TempData["alertMessage"] = "รหัสนักศึกษาไม่สามารถซ้ำได้";
                    ViewBag.MinorID = new SelectList(db.tblMinors, "MinorID", "MinorName", tblStudent.MinorID);
                    return View(tblStudent);
                }
                else
                {
                    tblStudent.StudID = Guid.NewGuid().ToString();
                    db.tblStudents.Add(tblStudent);

                    //Save User
                    tblUser TempUser = new tblUser();
                    TempUser.UserID = Guid.NewGuid().ToString();
                    TempUser.UserName = tblStudent.StudCode;
                    TempUser.Password = tblStudent.BirthDate.ToString("ddMMyyyy");
                    TempUser.relateID = tblStudent.StudID;
                    TempUser.relateTable = "tblStudent";
                    db.tblUsers.Add(TempUser);

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            ViewBag.MinorID = new SelectList(db.tblMinors, "MinorID", "MinorName", tblStudent.MinorID);
            return View(tblStudent);
        }

        // GET: tblStudents/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStudent tblStudent = db.tblStudents.Find(id);
            if (tblStudent == null)
            {
                return HttpNotFound();
            }
            ViewBag.MinorID = new SelectList(db.tblMinors, "MinorID", "MinorName", tblStudent.MinorID);
            return View(tblStudent);
        }

        // POST: tblStudents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudID,StudCode,FullName,MajorID,MinorID,Year,BirthDate,Tel,Email,Remark")] tblStudent tblStudent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblStudent).State = EntityState.Modified;
                db.SaveChanges();

                string relateTable = Convert.ToString(Session["relateTable"]);

                if (relateTable == "tblStudent")
                {
                    return RedirectToAction("Index", "Home", new { area = "" });
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            ViewBag.MinorID = new SelectList(db.tblMinors, "MinorID", "MinorName", tblStudent.MinorID);
            return View(tblStudent);
        }

        // GET: tblStudents/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStudent tblStudent = db.tblStudents.Find(id);
            if (tblStudent == null)
            {
                return HttpNotFound();
            }
            return View(tblStudent);
        }

        // POST: tblStudents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tblStudent tblStudent = db.tblStudents.Find(id);
            db.tblStudents.Remove(tblStudent);
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

        public ActionResult Register()
        {
            ViewBag.MinorID = new SelectList(db.tblMinors, "MinorID", "MinorName");
            return View();
        }

        // POST: tblStudents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "StudCode,FullName,MajorID,MinorID,Year,BirthDate,Tel,Email,Remark")] tblStudent tblStudent)
        {
            if (ModelState.IsValid)
            {
                if (db.tblStudents.Where(h => h.StudCode == tblStudent.StudCode).ToList().Count > 0)
                {
                    TempData["alertMessage"] = "รหัสนักศึกษาไม่สามารถซ้ำได้";
                    ViewBag.MinorID = new SelectList(db.tblMinors, "MinorID", "MinorName", tblStudent.MinorID);
                    return View(tblStudent);
                }
                else
                {
                    tblStudent.StudID = Guid.NewGuid().ToString();
                    db.tblStudents.Add(tblStudent);

                    //Save User
                    tblUser TempUser = new tblUser();
                    TempUser.UserID = Guid.NewGuid().ToString();
                    TempUser.UserName = tblStudent.StudCode;
                    TempUser.Password = tblStudent.BirthDate.ToString("ddMMyyyy");
                    TempUser.relateID = tblStudent.StudID;
                    TempUser.relateTable = "tblStudent";
                    db.tblUsers.Add(TempUser);

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            ViewBag.MinorID = new SelectList(db.tblMinors, "MinorID", "MinorName", tblStudent.MinorID);
            return View(tblStudent);
        }

    }
}
