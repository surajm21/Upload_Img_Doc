using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationMultiImages.Models;
using System.IO;

namespace WebApplicationMultiImages.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/
        MVCDBEntities db = new MVCDBEntities();
        public ActionResult Index()
        {
            return View(db.tblproducts.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(tblproduct p, HttpPostedFileBase []photo)
        {
            string imagename ="";
            string folderpath = Server.MapPath("~/Image/"+p.productName);
            if (!Directory.Exists(folderpath))
            {
                Directory.CreateDirectory(folderpath);
            }
            int i=1;
            foreach(HttpPostedFileBase h in photo)
           {
               string imgname = p.productName + i +Path.GetExtension(h.FileName);
               string imgpath = folderpath + "/" + imgname;
               h.SaveAs(imgpath);
               i++;
               imagename = imagename + "," + imgname;
            }
            imagename = imagename.Substring(1, imagename.Length - 1);
            p.productPhoto = imagename;
            db.tblproducts.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
	}
}