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

using Newtonsoft.Json;
using System.Web.Script.Serialization;

namespace SchoolTime.Controllers
{
    public class tblCourseHDsController : Controller
    {
        private SchoolTimeContext db = new SchoolTimeContext();


        // GET: tblCourseHDs
        public ActionResult Index()
        {
            string relateID = Convert.ToString(Session["relateID"]);
            string relateTable = Convert.ToString(Session["relateTable"]);
            if (Convert.ToString(Session["relateTable"]) == "tblStudent")
            {
                return View();
            }
            else if (Convert.ToString(Session["relateTable"]) == "tblTeacher")
            {
                var tblCourseHDs = db.tblCourseHDs.Include(t => t.tblSuject).Include(t => t.tblTeacher).Where(x => x.teachID == relateID && x.IsClose == false);
                return View(tblCourseHDs);
            }
            else
            {
                var tblCourseHDs = db.tblCourseHDs.Include(t => t.tblSuject).Include(t => t.tblTeacher);
                return View(tblCourseHDs.ToList());
            }
            
        }

        public ActionResult StudentsIndex()
        {
            return View();
        }

        public ActionResult DetailsStudents()
        {
            return View();
        }

        [HttpPost]
        public JsonResult getStudentsCourse()
        {
            //var Students = db.tblStudents.ToList();
            string relateID = Convert.ToString(Session["relateID"]);
            if (Convert.ToString(Session["relateTable"]) == "tblStudent")
            {
                var itemList = (from HD in db.tblCourseHDs
                                join DT in db.tblCourseDTs on HD.CourseHDID equals DT.CourseHDID
                                join TE in db.tblTeachers on HD.teachID equals TE.teachID
                                join SC in db.tblSujects on HD.SujectID equals SC.SujectID
                                where DT.StudID.Equals(relateID) && HD.IsClose.Equals(false)
                                select new
                                {
                                    CourseHDID = HD.CourseHDID,
                                    CourseCode = HD.CourseCode,
                                    CourseYear = HD.CourseYear,
                                    NumCheckIN = HD.NumCheckIN,
                                    Semester = HD.Semester,
                                    TimeStart_txt = HD.TimeStart_txt,
                                    TimeEnd_txt = HD.TimeEnd_txt,
                                    TimeLate = HD.TimeLate + HD.TimeStart,
                                    Entitled = HD.Entitled,
                                    NotEntitled = HD.NotEntitled,
                                    Contact = HD.Contact,
                                    FullName = TE.FullName,
                                    SujectName = SC.SujectName
                                }).ToList();
                return Json(itemList, JsonRequestBehavior.AllowGet);
            }
            else
                return Json(null);
        }

        // GET: tblCourseHDs/Details/5
        public ActionResult Details(string id)
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
            return View(tblCourseHD);
        }

        // GET: tblCourseHDs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblCourseHDs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        #region Comment
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "CourseHDID,SujectID,CourseCode,CourseYear,Semester,teachID,TimeStart_txt,TimeEnd_txt,TimeLate,NumCheckIN,Entitled,NotEntitled,Contact")] tblCourseHD tblCourseHD)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        tblCourseHD.CourseHDID = Guid.NewGuid().ToString();
        //        db.tblCourseHDs.Add(tblCourseHD);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.SujectID = new SelectList(db.tblSujects, "SujectID", "SujectName", tblCourseHD.SujectID);
        //    ViewBag.teachID = new SelectList(db.tblTeachers, "teachID", "Fullname", tblCourseHD.teachID);
        //    return View(tblCourseHD);
        //}
        #endregion

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
                    CourseHD.IsClose = false;
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
                return Json(new { Success = 0});
            }

            return Json(new { Success = 0});
        }

        // GET: tblCourseHDs/Edit/5
        public ActionResult Edit(string id)
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

            return View(tblCourseHD);
        }

        // POST: tblCourseHDs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public JsonResult EditHD(string CourseHDID,
                                    string CourseCode,
                                    string SujectID,
                                    string CourseYear,
                                    string Semester,
                                    string teachID,
                                    string TimeStart_txt,
                                    string TimeEnd_txt,
                                    string TimeLate,
                                    string NumCheckIN,
                                    string Entitled,
                                    string NotEntitled,
                                    string Contact,
                                    string IsClose)
        {
            try
            {
                var errors = ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .Select(x => new { x.Key, x.Value.Errors })
                    .ToArray();
                if (ModelState.IsValid)
                {
                    //string TempID = CourseHD.CourseHDID;

                    //Delete Detail Old
                    var CourseDT = db.tblCourseDTs.Where(h => h.CourseHDID == CourseHDID);
                    db.tblCourseDTs.RemoveRange(CourseDT);
                    db.SaveChanges();

                    tblCourseHD HD = new tblCourseHD();
                    HD.CourseHDID = CourseHDID;
                    HD.CourseCode = CourseCode;
                    HD.SujectID = SujectID;
                    HD.CourseYear = Convert.ToInt32(CourseYear);
                    HD.Semester = Convert.ToInt32(Semester); 
                    HD.teachID = teachID;
                    HD.TimeStart_txt = TimeStart_txt;
                    HD.TimeEnd_txt = TimeEnd_txt;
                    HD.TimeLate = Convert.ToInt32(TimeLate); 
                    HD.NumCheckIN = Convert.ToInt32(NumCheckIN); 
                    HD.Entitled = Convert.ToInt32(Entitled); 
                    HD.NotEntitled = Convert.ToInt32(NotEntitled); 
                    HD.Contact = Convert.ToInt32(Contact);
                    if (IsClose == "1")
                    {
                        HD.IsClose = true;
                    }
                    else
                    {
                        HD.IsClose = false;
                    }

                    if (TimeStart_txt.Contains(":"))
                    {
                        string[] TempTimeStart = TimeStart_txt.Split(':');
                        HD.TimeStart = (Convert.ToInt32(TempTimeStart[0]) * 60) + Convert.ToInt32(TempTimeStart[1]);
                    }
                    else
                    {
                        HD.TimeStart = 0;
                    }

                    if (TimeEnd_txt.Contains(":"))
                    {
                        string[] TempTimeEnd = TimeEnd_txt.Split(':');
                        HD.TimeEnd = (Convert.ToInt32(TempTimeEnd[0]) * 60) + Convert.ToInt32(TempTimeEnd[1]);
                    }
                    else
                    {
                        HD.TimeEnd = 0;
                    }

                    db.Entry(HD).State = EntityState.Modified;
                    db.SaveChanges();

                    // If Sucess== 1 then Save/Update Successfull else there it has Exception
                    return Json(new { Success = 1, ex = "HD" });
                }
            }
            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.Message.ToString() });
            }

            return Json(new { Success = 0, ex = new Exception("Unable to save").Message.ToString() });
        }

        [HttpPost]
        public JsonResult EditDT(string CourseDT)
        {
            try
            {
                var errors = ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .Select(x => new { x.Key, x.Value.Errors })
                    .ToArray();
                if (ModelState.IsValid)
                {
                    var js = new JavaScriptSerializer();
                    var deserializedMenuItems = (object[])js.DeserializeObject(CourseDT);
                    //foreach (json DT in CourseDT)
                    //{
                    //    if (string.IsNullOrEmpty(DT[1]))
                    //    {
                    //        DT.CourseDTID = Guid.NewGuid().ToString();
                    //    }
                    //    db.tblCourseDTs.Add(DT);
                    //    db.SaveChanges();
                    //}
                    string CourseHDID = string.Empty;
                    string StudID = string.Empty;
                    foreach (Dictionary<string, object> newMenuItem in deserializedMenuItems)
                    {
                        CourseHDID = newMenuItem["CourseHDID"].ToString();
                        StudID = newMenuItem["StudID"].ToString();
                        tblCourseDT DT = new tblCourseDT();
                        DT.CourseHDID = CourseHDID;
                        DT.CourseDTID = Guid.NewGuid().ToString();
                        DT.StudID = StudID;
                        db.tblCourseDTs.Add(DT);
                        db.SaveChanges();
                    }

                    // If Sucess== 1 then Save/Update Successfull else there it has Exception
                    return Json(new { Success = 1, ex = "DT" });
                }
            }
            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.Message.ToString() });
            }

            return Json(new { Success = 0, ex = new Exception("Unable to save").Message.ToString() });
        }

        // GET: tblCourseHDs/Delete/5
        public ActionResult Delete(string id)
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
            return View(tblCourseHD);
        }

        // POST: tblCourseHDs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            //tblCourseHD tblCourseHD = db.tblCourseHDs.Find(id);
            //tblCourseDT tblCourseDT = db.

            var CourseHD = db.tblCourseHDs.Where(h => h.CourseHDID == id);
            var CourseDT = db.tblCourseDTs.Where(h => h.CourseHDID == id);
            var CheckIN = db.tblCheckINs.Where(h => h.CourseHDID == id);

            db.tblCourseDTs.RemoveRange(CourseDT);
            db.SaveChanges();

            db.tblCheckINs.RemoveRange(CheckIN);
            db.SaveChanges();

            db.tblCourseHDs.RemoveRange(CourseHD);
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

        [HttpGet]
        public JsonResult getDetail(string CourseHDID)
        {
            string relateID = Convert.ToString(Session["relateID"]);
            if (Convert.ToString(Session["relateTable"]) == "tblStudent")
            {
                var itemList = (from DT in db.tblCourseDTs
                                join ST in db.tblStudents on DT.StudID equals ST.StudID
                                join MN in db.tblMinors on ST.MinorID equals MN.MinorID
                                where DT.CourseHDID == CourseHDID && DT.StudID == relateID
                                select new
                                {

                                    StudID = DT.StudID,
                                    StudCode = ST.StudCode,
                                    FullName = ST.FullName,
                                    MinorName = MN.MinorName
                                }).ToList();
                return Json(itemList, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var itemList = (from DT in db.tblCourseDTs
                                join ST in db.tblStudents on DT.StudID equals ST.StudID
                                join MN in db.tblMinors on ST.MinorID equals MN.MinorID
                                where DT.CourseHDID == CourseHDID
                                select new
                                {

                                    StudID = DT.StudID,
                                    StudCode = ST.StudCode,
                                    FullName = ST.FullName,
                                    MinorName = MN.MinorName
                                }).ToList();
                return Json(itemList, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult getDetailALL(string CourseHDID)
        {
            string relateID = Convert.ToString(Session["relateID"]);
            if (Convert.ToString(Session["relateTable"]) == "tblStudent")
            {
                var itemList = (from DT in db.tblCourseDTs
                                join ST in db.tblStudents on DT.StudID equals ST.StudID
                                join MN in db.tblMinors on ST.MinorID equals MN.MinorID
                                where DT.CourseHDID == CourseHDID && DT.StudID == relateID
                                select new
                                {

                                    StudID = DT.StudID,
                                    StudCode = ST.StudCode,
                                    FullName = ST.FullName,
                                    MinorName = MN.MinorName
                                }).ToList();
                return Json(itemList, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var itemList = (from DT in db.tblCourseDTs
                                join ST in db.tblStudents on DT.StudID equals ST.StudID
                                join MN in db.tblMinors on ST.MinorID equals MN.MinorID
                                where DT.CourseHDID.StartsWith(CourseHDID)
                                select new
                                {

                                    StudID = DT.StudID,
                                    StudCode = ST.StudCode,
                                    FullName = ST.FullName,
                                    MinorName = MN.MinorName
                                }).ToList();
                return Json(itemList, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult getDetailShow(string CourseHDID)
        {
            string relateID = Convert.ToString(Session["relateID"]);
            if (Convert.ToString(Session["relateTable"]) == "tblStudent")
            {
                var itemList = (from DT in db.tblCourseDTs
                                join ST in db.tblStudents on DT.StudID equals ST.StudID
                                join MN in db.tblMinors on ST.MinorID equals MN.MinorID
                                where DT.CourseHDID.Equals(CourseHDID) && DT.StudID.Equals(relateID)
                                select new
                                {

                                    StudID = DT.StudID,
                                    StudCode = ST.StudCode,
                                    FullName = ST.FullName,
                                    MinorName = MN.MinorName
                                }).ToList();
                return Json(itemList, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var itemList = (from DT in db.tblCourseDTs
                                join ST in db.tblStudents on DT.StudID equals ST.StudID
                                join MN in db.tblMinors on ST.MinorID equals MN.MinorID
                                where DT.CourseHDID.Equals(CourseHDID)
                                select new
                                {

                                    StudID = DT.StudID,
                                    StudCode = ST.StudCode,
                                    FullName = ST.FullName,
                                    MinorName = MN.MinorName
                                }).ToList();
                return Json(itemList, JsonRequestBehavior.AllowGet);
            }
        }


        // POST: tblCourseHDs/Delete/5
        [HttpPost]
        public JsonResult SaveCheckTime(tblCheckIN tblCheckINsTemp)
        {
            var chkStud = db.tblStudents.Where(s => s.StudID == tblCheckINsTemp.StudID || s.StudCode == tblCheckINsTemp.StudID).ToList();
            if (chkStud.Count > 0)
            {
                tblCheckINsTemp.StudID = chkStud[0].StudID;
                var quote = (from h in db.tblCourseHDs
                             join d in db.tblCourseDTs on h.CourseHDID equals d.CourseHDID
                             join s in db.tblStudents on d.StudID equals s.StudID
                             where h.CourseHDID == tblCheckINsTemp.CourseHDID
                             && d.StudID == tblCheckINsTemp.StudID                                    
                             select h).ToList();
                if (quote.Count > 0)
                {
                    var chk = (from c in db.tblCheckINs
                               where c.CourseHDID == tblCheckINsTemp.CourseHDID
                               && c.StudID == tblCheckINsTemp.StudID
                               && c.NumCheck == tblCheckINsTemp.NumCheck
                               select c).ToList();
                    if (chk.Count > 0)
                    {
                        return Json(new { Success = 3 });
                    }
                    else
                    {

                        tblCheckINsTemp.CheckInID = Guid.NewGuid().ToString();
                        tblCheckINsTemp.TimeCheck = DateTime.Now;

                        db.tblCheckINs.Add(tblCheckINsTemp);
                        db.SaveChanges();
                        return Json(new { Success = 1 });
                    }
                }
                else
                {
                    return Json(new { Success = 2 });
                }
            }
            else
            {
                return Json(new { Success = 2 });
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

        [HttpGet]
        public JsonResult getDetailDT(string CourseHDID)
        {

            string relateID = Convert.ToString(Session["relateID"]);
            if (Convert.ToString(Session["relateTable"]) == "tblStudent")
            {
                var itemList = (from DT in db.tblCourseDTs
                                join ST in db.tblStudents on DT.StudID equals ST.StudID
                                where DT.CourseHDID.Equals(CourseHDID) 
                                && DT.StudID.Equals(relateID)
                                select new
                                {
                                    StudID = DT.StudID,
                                    StudCode = ST.StudCode,
                                    FullName = ST.FullName
                                }).ToList();
                return Json(itemList, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var itemList = (from DT in db.tblCourseDTs
                                join ST in db.tblStudents on DT.StudID equals ST.StudID
                                where DT.CourseHDID.StartsWith(CourseHDID)
                                select new
                                {
                                    StudID = DT.StudID,
                                    StudCode = ST.StudCode,
                                    FullName = ST.FullName
                                }).ToList();
                return Json(itemList, JsonRequestBehavior.AllowGet);
            }
            

        }

        [HttpGet]
        public JsonResult getDetailTime(string CourseHDID)
        {
            string relateID = Convert.ToString(Session["relateID"]);
            if (Convert.ToString(Session["relateTable"]) == "tblStudent")
            {

                var itemList = (from DT in db.tblCheckINs
                                where DT.CourseHDID.Equals(CourseHDID)
                                && DT.StudID.Equals(relateID)
                                orderby DT.NumCheck
                                select new
                                {
                                    StudID = DT.StudID,
                                    TimeCheck = DT.TimeCheck,
                                    NumCheck = DT.NumCheck
                                }).ToList();
                return Json(itemList, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var itemList = (from DT in db.tblCheckINs
                                where DT.CourseHDID.StartsWith(CourseHDID)
                                orderby DT.NumCheck
                                select new
                                {
                                    StudID = DT.StudID,
                                    TimeCheck = DT.TimeCheck,
                                    NumCheck = DT.NumCheck
                                }).ToList();
                return Json(itemList, JsonRequestBehavior.AllowGet);
            }

        }
    }
}
