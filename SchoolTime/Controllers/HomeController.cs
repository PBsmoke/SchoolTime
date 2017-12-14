using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web.Mvc;
using SchoolTime.DAL;
using SchoolTime.Models;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;

namespace SchoolTime.Controllers
{
    public class HomeController : Controller
    {
        private SchoolTimeContext db = new SchoolTimeContext();

        public ActionResult Index()
        {
            HttpCookie ckUserLogon = new HttpCookie("ckuserlogon");

            //if (string.IsNullOrEmpty(Session["UserID"].ToString()))

            if(string.IsNullOrEmpty(Session["UserID"] as string))
            {
                return RedirectToAction("Login");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult BarcodeImage(String barcodeText)
        {
            // generating a barcode here. Code is taken from QrCode.Net library
            QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
            QrCode qrCode = new QrCode();
            qrEncoder.TryEncode(barcodeText, out qrCode);
            GraphicsRenderer renderer = new GraphicsRenderer(new FixedModuleSize(4, QuietZoneModules.Four), Brushes.Black, Brushes.White);

            Stream memoryStream = new MemoryStream();
            renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, memoryStream);

            // very important to reset memory stream to a starting position, otherwise you would get 0 bytes returned
            memoryStream.Position = 0;

            var resultStream = new FileStreamResult(memoryStream, "image/png");
            resultStream.FileDownloadName = String.Format("{0}.png", barcodeText);

            return resultStream;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult login([Bind(Include = "UserName,Password")] tblUser tblUser)
        {
            HttpCookie ckUserLogon = new HttpCookie("ckuserlogon");
            var userlogon = (from c in db.tblUsers where c.UserName == tblUser.UserName && c.Password == tblUser.Password select c).ToList();

            if (userlogon.Count > 0)
            {
                Response.Cookies.Clear();
                #region
                ckUserLogon.Values["UserID"] = userlogon[0].UserID.ToString();
                ckUserLogon.Values["UserName"] = userlogon[0].UserName.ToString();
                ckUserLogon.Values["Password"] = userlogon[0].Password.ToString();
                ckUserLogon.Values["relateID"] = userlogon[0].relateID.ToString();
                ckUserLogon.Values["relateTable"] = userlogon[0].relateTable.ToString();
                ckUserLogon.Expires = DateTime.Now.AddHours(8);
                Response.Cookies.Add(ckUserLogon);

                Session["UserID"] = userlogon[0].UserID.ToString();
                Session["UserName"] = userlogon[0].UserName.ToString();
                Session["Password"] = userlogon[0].Password.ToString();
                Session["relateID"] = userlogon[0].relateID.ToString();
                Session["relateTable"] = userlogon[0].relateTable.ToString();

                #endregion
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}