using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;


namespace WebApplication3.Controllers
{
    public class StudentController : Controller
    {
        //
        // GET: /Student/
        MVCDBEntities db = new MVCDBEntities();

        public ActionResult Index()
        {
            List<Student> lst = db.Students.ToList();
            return View(lst);
        }

	}
}