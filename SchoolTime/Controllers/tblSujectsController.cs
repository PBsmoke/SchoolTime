using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using PagedList;
using System.Web.Mvc;
using SchoolTime.DAL;
using SchoolTime.Models;

namespace SchoolTime.Controllers
{
    public class tblSujectsController : Controller
    {
        private SchoolTimeContext db = new SchoolTimeContext();

        // GET: tblSujects
        public ActionResult Index()
        {
            return View(db.tblSujects.ToList());
        }

        // GET: tblSujects/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSuject tblSuject = db.tblSujects.Find(id);
            if (tblSuject == null)
            {
                return HttpNotFound();
            }
            return View(tblSuject);
        }

        // GET: tblSujects/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblSujects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SujectID,SujectCode,SujectName,SujectDetail")] tblSuject tblSuject)
        {
            if (ModelState.IsValid)
            {
                tblSuject.SujectID = Guid.NewGuid().ToString();
                db.tblSujects.Add(tblSuject);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblSuject);
        }

        // GET: tblSujects/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSuject tblSuject = db.tblSujects.Find(id);
            if (tblSuject == null)
            {
                return HttpNotFound();
            }
            return View(tblSuject);
        }

        // POST: tblSujects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SujectID,SujectCode,SujectName,SujectDetail")] tblSuject tblSuject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblSuject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblSuject);
        }

        // GET: tblSujects/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSuject tblSuject = db.tblSujects.Find(id);
            if (tblSuject == null)
            {
                return HttpNotFound();
            }
            return View(tblSuject);
        }

        // POST: tblSujects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tblSuject tblSuject = db.tblSujects.Find(id);
            db.tblSujects.Remove(tblSuject);
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
