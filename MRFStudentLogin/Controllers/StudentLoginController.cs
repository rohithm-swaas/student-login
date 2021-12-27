using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MRFStudentLogin.Models;

namespace MRFStudentLogin.Controllers
{
    public class StudentLoginController : Controller
    {
        StudentDB Details = new StudentDB();
        // GET: StudentLogin
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult UpdateLoginStatus(StudentModel std)
        {
            Session["userid"] = std.userid;
            return Json(Details.UpdateLoginStatus(std), JsonRequestBehavior.AllowGet);
        }
    }
}