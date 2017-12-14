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
    public class tblMinorsController : Controller
    {
        private SchoolTimeContext db = new SchoolTimeContext();

        // GET: tblMinors
        public ActionResult Index()
        {
            var tblMinors = db.tblMinors.Include(t => t.tblMajor);
            return View(tblMinors.ToList());
        }

        // GET: tblMinors/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblMinor tblMinor = db.tblMinors.Find(id);
            if (tblMinor == null)
            {
                return HttpNotFound();
            }
            return View(tblMinor);
        }

        // GET: tblMinors/Create
        public ActionResult Create()
        {
            ViewBag.MajorID = new SelectList(db.tblMajors, "MajorID", "MajorName");
            return View();
        }

        // POST: tblMinors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MinorID,MajorID,MinorCode,MinorName,MinorDetail")] tblMinor tblMinor)
        {
            if (ModelState.IsValid)
            {
                tblMinor.MinorID = Guid.NewGuid().ToString();
                db.tblMinors.Add(tblMinor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MajorID = new SelectList(db.tblMajors, "MajorID", "MajorName", tblMinor.MajorID);
            return View(tblMinor);
        }

        // GET: tblMinors/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblMinor tblMinor = db.tblMinors.Find(id);
            if (tblMinor == null)
            {
                return HttpNotFound();
            }
            ViewBag.MajorID = new SelectList(db.tblMajors, "MajorID", "MajorName", tblMinor.MajorID);
            return View(tblMinor);
        }

        // POST: tblMinors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MinorID,MajorID,MinorCode,MinorName,MinorDetail")] tblMinor tblMinor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblMinor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MajorID = new SelectList(db.tblMajors, "MajorID", "MajorName", tblMinor.MajorID);
            return View(tblMinor);
        }

        // GET: tblMinors/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblMinor tblMinor = db.tblMinors.Find(id);
            if (tblMinor == null)
            {
                return HttpNotFound();
            }
            return View(tblMinor);
        }

        // POST: tblMinors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tblMinor tblMinor = db.tblMinors.Find(id);
            db.tblMinors.Remove(tblMinor);
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
