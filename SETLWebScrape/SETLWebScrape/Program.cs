using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace SETLWebScrape {
    class Program {
        [STAThread]
        static void Main(string[] args) {
            WebBrowser browser = new WebBrowser();
            browser.AllowNavigation = true;

            browser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(WebBrowser_DocumentCompleted);
            browser.Navigate("http://www.septl.org/TL/ourtools.php");
            browser.ScriptErrorsSuppressed = true;

            while (browser.ReadyState != WebBrowserReadyState.Complete) {
                Application.DoEvents();
                Thread.Sleep(100);
            }
        }

        public static void WebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e) {
            WebBrowser browser = sender as WebBrowser;
            browser.DocumentCompleted -= WebBrowser_DocumentCompleted;

            HtmlElementCollection categories = browser.Document.GetElementsByTagName("div");
            List<Category> categoriesParsed = new List<Category>();

            object[] jQueryScript = { "$('span.tName').click();" };
            browser.Document.InvokeScript("eval", jQueryScript);

            //// adding each section
            //foreach (HtmlElement category in categories) {
            //    if (category.GetAttribute("classname").ToString() == "aCategory") {
            //        Category newCat = new Category(category.Id);

            //        HtmlElementCollection possibleTools = category.GetElementsByTagName("span");
            //        List<Tool> toolsParsed = new List<Tool>();

            //        // adding each tool in the section                  
            //        foreach (HtmlElement item in possibleTools) {
            //            if (item.GetAttribute("classname").ToString() == "tName") {
            //                string id = item.GetAttribute("data-id").ToString();

            //                string name = item.GetAttribute("innerhtml").ToString();
            //                name = name.Substring(0, name.IndexOf('<')).Replace(@"\", "");

            //                item.Parent.Id = "theParent";

                            

            //                HtmlElementCollection spans = item.Parent.GetElementsByTagName("span");
            //                foreach (HtmlElement span in spans) {
            //                    span.InvokeMember("onclick");
            //                }

            //                newCat.AddTool(new Tool {
            //                    id = id,
            //                    name = name,
            //                });                       

            //                // adding tool fields
            //                HtmlElementCollection possibleFields = item.Parent.GetElementsByTagName("li");
            //                foreach (HtmlElement field in possibleFields) {
                                
            //                }

            //                item.Parent.Id = null;
            //            }
            //        }
            //        categoriesParsed.Add(newCat);
            //    }
            //}
            System.IO.File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads\\SETLTools.txt", JsonConvert.SerializeObject(browser.Document));           
        }

        public class Category {
            public string name { get; set; }
            public List<Tool> Tools { get; set; }

            public Category(string name) {
                this.name = name;
                this.Tools = new List<Tool>();
            }

            public void AddTool(Tool tool) {
                Tools.Add(tool);
            }
        }

        public class Tool {
            public string name { get; set; }
            public string id { get; set; }
        }
    }
}