using Space_CF_Project.Models.Context;
using Space_CF_Project.Models.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Web.WebPages.Html;
using System.Web.WebSockets;
using SelectListItem = System.Web.Mvc.SelectListItem;

namespace Space_CF_Project.Controllers
{
    
    public class MainController : Controller
    {
        // GET: Main
        private CONTEXT db = new CONTEXT();

        [HttpGet]
        [Authorize]
        public ActionResult BlogPage()
        {
            var status = db.TBLGonderis.Where(a => a.GonID > 0);
            foreach (var item in status)
            {
                ViewData["GonPicture"] = item.GonPicture;
                ViewData["GonBaslık"] = item.GonBaslık;
                ViewData["GonText"] = item.GonText;
                ViewData["DateTime"] = item.DateTime;
                ViewData["UserID"] = item.UserID;
                ViewData["KatID"] = item.KatID;
            }
            return View();
        }

        [HttpPost,ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult BlogPage(TBLGonderi gonderi)
        {
            return View(gonderi);
        }
        [Authorize]
        public ActionResult BlogSinglePage()
        {
            //ViewBag.Title("Blog Single Page");
            return View(); 
        }


        [Authorize]
        public  ActionResult HomePage()
        {
            if ((int)Session["UserID"] == 1)
            {
                ViewData["User"] = "Hoşgeldin Sir, BFE";
            }
            else
            {
                ViewData["User"]="Hoşgeldiniz Sayın, " + Session["UserAd"].ToString() +" "+ Session["UserSoyad"].ToString();
            }
            return View();
        }



        [HttpGet]
        [Authorize]
        public ActionResult Paylasım()
        {
           
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Paylasım(TBLGonderi gonderi)
        {
            var UserID = Session["UserID"];
            if (Request.Files.Count > 0)
            {
                string dosyaadı = Path.GetFileName(Request.Files[0].FileName);
                string uzantı = Path.GetExtension(Request.Files[0].FileName);
                string yol = dosyaadı + uzantı;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                gonderi.GonPicture = dosyaadı + uzantı;
            }   
            db.TBLGonderis.Add(gonderi);
            gonderi.UserID = (int)UserID;
            gonderi.DateTime = DateTime.Now;    
            db.SaveChanges();  
            return RedirectToAction("BlogPage");
        }
        [Authorize]
        public ActionResult PortfolioDetails()
        {
            //ViewBag.Title("Portfolio Details");
            return View(); 
        }

        public ActionResult ProfilPage() 
        {
            ViewData["ProfilAD"] = Session["UserAd"].ToString() + " Profili";
            ViewData["UserAd"] = Session["UserAd"].ToString();
            ViewData["UserSoyad"] = Session["UserSoyad"].ToString();
            ViewData["UserMail"] = Session["UserMail"].ToString();
            return View();
        }

        [AllowAnonymous]
        public ActionResult StateBlogPage()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult StateBlogSinglePage()
        {
            return View();
        }
    }
}