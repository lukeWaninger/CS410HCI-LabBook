using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using HtmlAgilityPack;

namespace SETLWebScrape {
    class Program {


        [STAThread]
        static void Main(string[] args) {
            string setlUrl = "http://www.septl.org/TL/ourtools.php";

            WebBrowser browser = new WebBrowser();
            browser.AllowNavigation = true;
            browser.ScriptErrorsSuppressed = true;
            browser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(WebBrowser_DocumentCompleted);

            browser.Navigate(setlUrl);
            while (browser.ReadyState != WebBrowserReadyState.Complete) {
                Application.DoEvents();
                Thread.Sleep(100);
            }
        }

        public static void WebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e) {
            string localpath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads\\";

            WebBrowser browser = sender as WebBrowser;
            browser.DocumentCompleted -= WebBrowser_DocumentCompleted;

                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.Load(localpath + "SEPTL.html");

            HtmlNodeCollection categories = doc.DocumentNode.SelectNodes("//*[contains(@class, 'aCategory')]");
            List<Category> categoriesParsed = new List<Category>();

            // adding each section
            List<string> existingTools = new List<string>();

            if (categories != null) {
                foreach (HtmlNode category in categories) {
                    Category newCat = new Category(category.Id);

                    HtmlNodeCollection possibleTools = category.ChildNodes;
                    List<Tool> toolsParsed = new List<Tool>();

                    // adding each tool in the section                  
                    foreach (HtmlNode item in possibleTools) {
                        try {
                            string id = item.ChildNodes[0].GetAttributeValue("data-id", "");

                            string name = item.ChildNodes[0].InnerHtml;
                            if (name.Contains("<")) {
                                name = name.Substring(0, name.IndexOf('<')).Replace(@"\", "");
                            }
                            if (name[name.Length - 1] == '(') {
                                name = name.Substring(0, name.LastIndexOf("(")).Trim();
                            }


                            int available = 0;
                            if (item.ChildNodes[0].InnerText.Contains("Available")) {
                                available = 1;
                            }

                            //string description, brand, model, lateFine;
                            //try {
                            //    description = item.ChildNodes[1].FirstChild.FirstChild.InnerText;
                            //    description = description.Substring(description.IndexOf(":") + 1);

                            //    brand = item.ChildNodes[1].FirstChild.ChildNodes[2].InnerText;
                            //    brand = brand.Substring(brand.IndexOf(":") + 1);

                            //    model = item.ChildNodes[1].FirstChild.ChildNodes[3].InnerText;
                            //    model = model.Substring(model.IndexOf(":") + 1);

                            //    lateFine = item.ChildNodes[1].FirstChild.ChildNodes[4].InnerText;
                            //    lateFine = lateFine.Substring(lateFine.IndexOf(":") + 1);
                            //}
                            //catch (Exception ex) {
                            //    description = "";
                            //    brand = "";
                            //    model = "";
                            //    lateFine = "";
                            //}
                            if (!existingTools.Contains(name.ToUpper().Trim())) {
                                newCat.AddTool(new Tool {
                                    id = id,
                                    name = name,
                                    available = available,
                                    //description = description,
                                    //brand = brand,
                                    //lateFine = lateFine,
                                    //model = model,
                                });
                                existingTools.Add(name.ToUpper().Trim());
                            }
                            
                        }
                        catch (Exception ex) { }
                    }
                    categoriesParsed.Add(newCat);
                }
                existingTools.Sort();
                existingTools.ForEach(x => Console.WriteLine(x));
                Console.ReadKey();

                System.IO.File.WriteAllText(localpath + "SETLTools.txt", JsonConvert.SerializeObject(categoriesParsed));
            }
        }
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
        public int available { get; set; }
        //public string description { get; set; }
        //public string brand { get; set; }
        //public string model { get; set; }
        //public string lateFine { get; set; }
    }    
}
