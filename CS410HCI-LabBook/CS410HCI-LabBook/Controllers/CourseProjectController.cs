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
        private string loadTimeFilePath = AppDomain.CurrentDomain.BaseDirectory + "Content\\Recourse Documents\\loadTimes.txt";

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
            List<double> times = new List<double>();

            try {
                using (StreamReader reader = new StreamReader(loadTimeFilePath)) {
                    List<string> s = reader.ReadToEnd().Split(';').ToList();

                    foreach (string e in s) {
                        double time = 0;
                        if (double.TryParse(e, out time)) {
                            times.Add(time);
                        }
                    }
                }

                double averageLoadTime = times.Average();

                ViewBag.Acceptable = averageLoadTime < 5 ? "within" : "not within";
                ViewBag.NumberOfMapLoads = times.Count;
                ViewBag.AverageLoadTime = string.Format("{0:0.00} seconds", averageLoadTime);
            }
            catch (Exception ex) {
                ViewBag.Acceptable = "SERVER FAILED TO LOAD TIMES";
                ViewBag.NumberOfMapLoads = "SERVER FAILED TO LOAD TIMES";
                ViewBag.AverageLoadTime = "SERVER FAILED TO LOAD TIMES";
            }
            return View();
        }

        [HttpPost]
        public ActionResult LogLoadTime(string duration) {
            if (string.IsNullOrEmpty(duration)) return Json("failing", JsonRequestBehavior.AllowGet);

            try {
                using (StreamWriter writer = new StreamWriter(loadTimeFilePath, true)) {
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