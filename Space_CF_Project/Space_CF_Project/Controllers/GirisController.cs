using Space_CF_Project.Models.Context;
using Space_CF_Project.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Web.Security;

namespace Space_CF_Project.Controllers
{
    public class GirisController : Controller
    {
        private CONTEXT db = new CONTEXT();
        private TBLUser tbluser = new TBLUser();
        [HttpGet]
        public ActionResult Login() //GİRİŞ YAP
        {   
            ViewBag.Title = "Login";
            return View(tbluser);
        }

        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Login(TBLUser user)
        {
            
            var USER = db.TBLUsers.FirstOrDefault(x=>x.UserMail == user.UserMail && x.UserSifre== user.UserSifre);
            if (USER != null)
            {
                FormsAuthentication.SetAuthCookie(USER.UserID.ToString(),false);
                Session["UserID"] = USER.UserID;
                Session["UserAd"] = USER.UserAd;
                Session["UserSoyad"] = USER.UserSoyad;
                Session["UserMail"] = USER.UserMail;
                return RedirectToAction("HomePage","Main");
            }
            else
            {
                ViewBag.LoginStatus = 0;
                return RedirectToAction("Login","Giris");
            }
        }
        /*
            CONTEXT db = new CONTEXT();
            var status = db.TBLUsers.Where(a => a.UserMail == user.UserMail && a.UserSifre == user.UserSifre).FirstOrDefault();
            if (status == null)
            {
                ViewBag.LoginStatus = 0;
            }
            else
            {
                //Session İşlemi yazıyoruz...HttpContext.Session.Set
                return RedirectToAction("HomePage", "Main");
            }
            return View(user);*/



        [HttpGet]
        public ActionResult SignUp() //KAYIT YAP
        {
            //TBLUseres.Add(new TBLUser() { Ad =""});
            ViewBag.Title = "SignUp";
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult SignUp(TBLUser user) //Hesap Kayıt 
        {
            if (!String.IsNullOrEmpty(user.UserMail))
            {
                var status = db.TBLUsers.Where(a => a.UserMail == user.UserMail).FirstOrDefault();
                if (status != null)
                {
                    if (status.UserMail == user.UserMail)
                    {
                        ViewBag.LoginStatus = 0;
                    }

                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        db.TBLUsers.Add(user);
                        db.SaveChanges();
                        return RedirectToAction("Login");
                    }
                }
            }
                return View();
        }

        [HttpGet]
        public ActionResult SifremiUnuttum()
        {
            ViewBag.Title = "Forgot Password";
            return View();
        }

        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult SifremiUnuttum(TBLUser user)
        {
            var status = db.TBLUsers.Where(a => a.UserMail == user.UserMail).FirstOrDefault();
            if (status != null)
            {
                status.UserSifre = user.UserSifre;
                db.SaveChanges();
                return View("Login");
            }
            else
            {
                ViewBag.LoginStatus = 0;
            }
            return View();
        }

    }
}


/*
    Contexleri oluşturduktan sonra Web.config sayfasına yazılır
    Enable-Migrations
    migrations'ta true yaptıktan sonra
    Update-database
 */