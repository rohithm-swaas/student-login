using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MRFStudentLogin.Models;

namespace MRFStudentLogin.Controllers
{
    public class MRFLoginController : Controller
    {
        MRFDB Page = new MRFDB();
        // GET: MRFLogin
        public ActionResult Index()
        {
            return View();
        }

        
        public JsonResult Add(MRFModel mrf)
        {
            return Json(Page.Add(mrf), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Edit(int id, int edit)
        {
            ViewBag.edit = edit;
            ViewBag.id = id;
            return View("Index");
        }
    }
}