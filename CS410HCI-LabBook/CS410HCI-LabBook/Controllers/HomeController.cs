using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CS410HCI_LabBook.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Project1()
        {
            ViewBag.Message = "The page for project 1";

            return View();
        }

        public ActionResult Project2()
        {
            ViewBag.Message = "The page for project 2";

            return View();
        }
        public ActionResult Project3()
        {
            ViewBag.Message = "The page for project 3";

            return View();
        }
        public ActionResult Project4()
        {
            ViewBag.Message = "The page for project 4";

            return View();
        }

        public ActionResult CourseProject()
        {
            ViewBag.Message = "The page for the course project";

            return View();
        }
    }
}