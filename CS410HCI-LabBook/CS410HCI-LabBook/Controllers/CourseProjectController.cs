using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CS410HCI_LabBook.ViewModels;
using System.IO;

namespace CS410HCI_LabBook.Controllers
{
    public class CourseProjectController : Controller {
        // GET: CourseProject/Ethnography
        public ActionResult Ethnography() {
            return View();
        }

        // GET: CourseProject/Scenarios
        public ActionResult Scenarios() {
            return View();
        }

        // GET: CourseProject/DraftLayout
        public ActionResult DraftLayout() {
            return View();
        }

        // GET: CourseProject/FocusGroup
        public ActionResult FocusGroup() {
            return View();
        }

        // GET: Course Project/UI
        public ActionResult UI() {
            // get average ui interface load time
            string path = AppDomain.CurrentDomain.BaseDirectory + "Content\\Recourse Documents\\loadTimes.txt";
            List<double> times = new List<double>();
            using (StreamReader reader = new StreamReader(path)) {
                List<string> s = reader.ReadToEnd().Split(';').ToList();
                
                foreach (string e in s) {
                    double time = 0;
                    if (double.TryParse(e, out time)) {
                        times.Add(time);
                    }
                }
            }

            ViewBag.AverageLoadTime =  string.Format("{0:0.00} seconds", times.Average());
            return View();
        }

        [HttpGet]
        public ActionResult FindSearchValues(string searchInput = "") {
            MapContentViewModel vm = new MapContentViewModel();

            List<string> allTools = new List<string>();
            foreach (Section s in vm.Sections) {
                foreach (Tool t in s.ToolList) {
                    if (!String.IsNullOrEmpty(searchInput)) {
                        if (t.Name.StartsWith(searchInput)) {
                            allTools.Add(t.Name);
                        }
                    }
                    else allTools.Add(t.Name);
                }
                s.ToolList.ForEach(t => allTools.Add(t.Name));
            }
            allTools = allTools.Distinct().ToList();
            allTools.OrderBy(t => t);

            return Json(allTools, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult LogLoadTime(string duration) {
            if (string.IsNullOrEmpty(duration)) return Json("failing", JsonRequestBehavior.AllowGet);

            string path = AppDomain.CurrentDomain.BaseDirectory + "Content\\Recourse Documents\\loadTimes.txt";
            try {
                using (StreamWriter writer = new StreamWriter(path, true)) {
                    double seconds = 0;
                    if (double.TryParse(duration, out seconds)) {
                        writer.Write(seconds / 1000 + ";");
                    }
                }
            }
            catch (Exception ex) {
                return Json("failing", JsonRequestBehavior.AllowGet);
            }
            return Json("success", JsonRequestBehavior.AllowGet);
        }
    }
}