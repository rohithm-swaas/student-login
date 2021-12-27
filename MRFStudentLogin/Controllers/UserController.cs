using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MRFStudentLogin.Models;

namespace MRFStudentLogin.Controllers
{
    public class UserController : Controller
    {
        UserDB Person = new UserDB();
        // GET: User
        public ActionResult use()
        {
            return View();
        }
        public JsonResult List()
        {
            return Json(Person.ListAll(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(int id)
        {
            var UserModel = Person.prefilling().Find(x => x.id.Equals(id));
            return Json(UserModel, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(MRFModel Student)
        {
            return Json(Person.Update(Student), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int id)
        {
            return Json(Person.Delete(id), JsonRequestBehavior.AllowGet);
        }
    }
}