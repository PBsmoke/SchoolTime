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
    public class tblMajorsController : Controller
    {
        private SchoolTimeContext db = new SchoolTimeContext();

        // GET: tblMajors
        public ActionResult Index()
        {
            return View(db.tblMajors.ToList());
        }

        // GET: tblMajors/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblMajor tblMajor = db.tblMajors.Find(id);
            if (tblMajor == null)
            {
                return HttpNotFound();
            }
            return View(tblMajor);
        }

        // GET: tblMajors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblMajors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MajorID,MajorCode,MajorName,MajorDetail")] tblMajor tblMajor)
        {
            if (ModelState.IsValid)
            {
                tblMajor.MajorID = Guid.NewGuid().ToString();
                db.tblMajors.Add(tblMajor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblMajor);
        }

        // GET: tblMajors/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblMajor tblMajor = db.tblMajors.Find(id);
            if (tblMajor == null)
            {
                return HttpNotFound();
            }
            return View(tblMajor);
        }

        // POST: tblMajors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MajorID,MajorCode,MajorName,MajorDetail")] tblMajor tblMajor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblMajor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblMajor);
        }

        // GET: tblMajors/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblMajor tblMajor = db.tblMajors.Find(id);
            if (tblMajor == null)
            {
                return HttpNotFound();
            }
            return View(tblMajor);
        }

        // POST: tblMajors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tblMajor tblMajor = db.tblMajors.Find(id);
            db.tblMajors.Remove(tblMajor);
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
