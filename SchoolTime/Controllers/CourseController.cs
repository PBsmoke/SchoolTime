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
    public class CourseController : Controller
    {
        private SchoolTimeContext db = new SchoolTimeContext();

        // GET: Course
        public ActionResult Index()
        {
            return View(db.uv_Course.ToList());
        }

        // GET: Course/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            uv_Course uv_Course = db.uv_Course.Find(id);
            if (uv_Course == null)
            {
                return HttpNotFound();
            }
            return View(uv_Course);
        }

        // GET: Course/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Course/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public JsonResult Create(tblCourseHD CourseHD)
        {
            try
            {
                var errors = ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .Select(x => new { x.Key, x.Value.Errors })
                    .ToArray();

                if (ModelState.IsValid)
                {

                    // If sales main has SalesID then we can understand we have existing sales Information
                    // So we need to Perform Update Operation
                    string TempID = Guid.NewGuid().ToString();

                    CourseHD.CourseHDID = TempID;
                    if (CourseHD.TimeStart_txt.Contains(":"))
                    {
                        string[] TempTimeStart = CourseHD.TimeStart_txt.Split(':');
                        CourseHD.TimeStart = (Convert.ToInt32(TempTimeStart[0]) * 60) + Convert.ToInt32(TempTimeStart[0]);
                    }
                    else
                    {
                        CourseHD.TimeStart = 0;
                    }

                    if (CourseHD.TimeEnd_txt.Contains(":"))
                    {
                        string[] TempTimeEnd = CourseHD.TimeEnd_txt.Split(':');
                        CourseHD.TimeEnd = (Convert.ToInt32(TempTimeEnd[0]) * 60) + Convert.ToInt32(TempTimeEnd[0]);
                    }
                    else
                    {
                        CourseHD.TimeEnd = 0;
                    }

                    foreach (tblCourseDT DT in CourseHD.tblCourseDTs)
                    {
                        DT.CourseHDID = TempID;
                        DT.CourseDTID = Guid.NewGuid().ToString();
                    }

                    db.tblCourseHDs.Add(CourseHD);
                    db.SaveChanges();

                    // If Sucess== 1 then Save/Update Successfull else there it has Exception
                    return Json(new { Success = 1 });
                }
            }
            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0 });
            }

            return Json(new { Success = 0 });
        }
        // GET: Course/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            uv_Course uv_Course = db.uv_Course.Find(id);
            if (uv_Course == null)
            {
                return HttpNotFound();
            }
            return View(uv_Course);
        }

        // POST: Course/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseHDID,CourseCode,teachID,teachCode,SujectCode,TimeStart_txt,TimeStart,TimeEnd_txt,TimeEnd,CourseYear,Semester,FullNameT,SujectID,SujectName,TimeLate,NumCheckIN,Entitled,NotEntitled,Contact,CourseDTID,StudID,StudCode,FullNameS,MinorID,MinorCode,MinorName")] uv_Course uv_Course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uv_Course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uv_Course);
        }

        // GET: Course/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            uv_Course uv_Course = db.uv_Course.Find(id);
            if (uv_Course == null)
            {
                return HttpNotFound();
            }
            return View(uv_Course);
        }

        // POST: Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            uv_Course uv_Course = db.uv_Course.Find(id);
            db.uv_Course.Remove(uv_Course);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult QRCode(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCourseHD tblCourseHD = db.tblCourseHDs.Find(id);
            if (tblCourseHD == null)
            {
                return HttpNotFound();
            }
            ViewBag.SujectID = new SelectList(db.tblSujects, "SujectID", "SujectName", tblCourseHD.SujectID);
            ViewBag.teachID = new SelectList(db.tblTeachers, "teachID", "Fullname", tblCourseHD.teachID);
            return View(tblCourseHD);
        }

        [HttpPost]
        public JsonResult getStudents()
        {
            //var Students = db.tblStudents.ToList();
            var Students = db.tblStudents.Include(n => n.tblMinor).Select(x => new
            {
                StudID = x.StudID,
                StudCode = x.StudCode,
                FullName = x.FullName,
                MinorName = x.tblMinor.MinorName
            }).ToList();
            return Json(Students);
        }

        [HttpPost]
        public JsonResult getSujects()
        {
            var Students = db.tblSujects.Select(x => new
            {
                SujectID = x.SujectID,
                SujectCode = x.SujectCode,
                SujectName = x.SujectName
            }).ToList();
            return Json(Students);
        }

        [HttpPost]
        public JsonResult getTeachers()
        {
            var Students = db.tblTeachers.Include(n => n.tblMajor).Select(x => new
            {
                teachID = x.teachID,
                teachCode = x.teachCode,
                FullName = x.FullName,
                MajorName = x.tblMajor.MajorName
            }).ToList();
            return Json(Students);
        }

        // POST: tblCourseHDs/Delete/5
        [HttpPost]
        public void SaveCheckTime(tblCheckIN tblCheckINs)
        {

            var quote = (from h in db.tblCourseHDs
                         join d in db.tblCourseDTs on h.CourseHDID equals d.CourseHDID
                         where h.CourseHDID == tblCheckINs.CourseHDID && d.StudID == tblCheckINs.StudID
                         select h).ToList();
            if (quote.Count > 0)
            {
                tblCheckINs.CheckInID = Guid.NewGuid().ToString();
                tblCheckINs.TimeCheck = DateTime.Now;

                db.tblCheckINs.Add(tblCheckINs);
                db.SaveChanges();
            }
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
