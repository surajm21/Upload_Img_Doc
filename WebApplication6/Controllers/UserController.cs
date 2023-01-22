using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication6.Models;
using System.IO;

namespace WebApplication6.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        MVCDBEntities db = new MVCDBEntities();
        public ActionResult Index()
        {
            List<tblUser> lst = db.tblUsers.ToList();

            return View(lst);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(tblUser t, HttpPostedFileBase photo, HttpPostedFileBase document)
        {
            if (photo.ContentLength > 0)
            {
                string photoname = t.UserName + Path.GetExtension(photo.FileName);
                string imgpath = Server.MapPath("~/photos/" + photoname);
                photo.SaveAs(imgpath);
                t.UserPhoto = photoname;
            }
            if( document.ContentLength > 0 )
            {
                string documentname = t.Document + Path.GetExtension(document.FileName);
                string docpath = Server.MapPath("~/document/" + documentname);
                document.SaveAs(docpath);
                t.Document = documentname;
            }

                
              
                db.tblUsers.Add(t);
                db.SaveChanges();

                return RedirectToAction("Index");
                
            }
                    

        }



        //[HttpPost]
        //public ActionResult Create(tblUser t, HttpPostedFileBase photo, HttpPostedFileBase document)
        //{
        //    if (photo.ContentLength > 0 && document.ContentLength > 0)
        //    {
        //        string photoname = t.UserName + Path.GetExtension(photo.FileName);
        //        string imgpath = Server.MapPath("~/photos/" + photoname);

        //        string documentname = t.Document + Path.GetExtension(document.FileName);
        //        string docpath = Server.MapPath("~/document/" + documentname);

        //        photo.SaveAs(imgpath);
        //        t.UserPhoto = photoname;

        //        document.SaveAs(docpath);
        //        t.Document = documentname;

        //        db.tblUsers.Add(t);
        //        db.SaveChanges();

        //        return RedirectToAction("Index");

        //    }
        //    return View();

        //}


    }
