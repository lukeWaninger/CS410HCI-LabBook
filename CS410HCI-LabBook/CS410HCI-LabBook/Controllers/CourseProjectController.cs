using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CS410HCI_LabBook.ViewModels;

namespace CS410HCI_LabBook.Controllers
{
    public class CourseProjectController : Controller
    {
        // GET: CourseProject/Ethnography
        public ActionResult Ethnography()
        {
            return View();
        }

        // GET: CourseProject/Scenarios
        public ActionResult Scenarios()
        {
            return View();
        }

        // GET: CourseProject/DraftLayout
        public ActionResult DraftLayout()
        {
            return View();
        }

        // GET: CourseProject/FocusGroup
        public ActionResult FocusGroup()
        {
            return View();
        }

        // GET: Course Project/UI
        public ActionResult UI()
        {
            return View(new MapContentViewModel());
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
    }
}