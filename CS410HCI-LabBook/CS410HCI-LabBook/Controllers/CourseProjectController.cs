using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CS410HCI_LabBook.Controllers
{
    public class CourseProjectController : Controller
    {
        // GET: CourseProject
        public ActionResult Ethnography()
        {
            return View();
        }

        // GET: CourseProject
        public ActionResult Scenarios()
        {
            return View();
        }

        // GET: CourseProject
        public ActionResult DraftLayout()
        {
            return View();
        }

        // GET: CourseProject
        public ActionResult FocusGroup()
        {
            return View();
        }
        public ActionResult UI()
        {
            return View();
        }
    }
}