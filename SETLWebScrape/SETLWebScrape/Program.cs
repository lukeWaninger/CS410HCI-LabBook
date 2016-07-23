using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using Newtonsoft.Json;
using System.IO;

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
            WebBrowser browser = sender as WebBrowser;
            browser.DocumentCompleted -= WebBrowser_DocumentCompleted;

            HtmlElementCollection categories = browser.Document.GetElementsByTagName("div");
            List<Category> categoriesParsed = new List<Category>();

            // adding each section
            foreach (HtmlElement category in categories) {
                if (category.GetAttribute("classname").ToString() == "aCategory") {
                    Category newCat = new Category(category.Id);

                    HtmlElementCollection possibleTools = category.GetElementsByTagName("span");
                    List<Tool> toolsParsed = new List<Tool>();

                    // adding each tool in the section                  
                    foreach (HtmlElement item in possibleTools) {
                        if (item.GetAttribute("classname").ToString() == "tName") {
                            string id = item.GetAttribute("data-id").ToString();

                            string name = item.GetAttribute("innerhtml").ToString();
                            name = name.Substring(0, name.IndexOf('<')).Replace(@"\", "");

                            #region
                            //// build post request
                            //string url = browser.Url.ToString();
                            //Encoding encoding = Encoding.UTF8;
                            //byte[] postData = encoding.GetBytes("zid=" + id.ToString());


                            //CookieContainer container = new CookieContainer();
                            //foreach (string cookie in browser.Document.Cookie.Split(';')) {
                            //    string nameA = cookie.Split('=')[0];
                            //    string value = cookie.Substring(name.Length + 1);
                            //    string path = "/";
                            //    string domain = "setl.org";
                            //    container.Add(new Cookie(nameA.Trim(), value.Trim(), path, domain));
                            //}

                            //WebRequest request = WebRequest.Create(url);

                            //HttpWebRequest httpRequest = request as HttpWebRequest;
                            ////httpRequest.Date = DateTime.Now;
                            //httpRequest.Accept = "*/*";
                            //httpRequest.Referer = "http://www.septl.org/TL/ourtools.php";
                            //System.Net.ServicePointManager.Expect100Continue = false;
                            //httpRequest.Expect = "200 OK";
                            //httpRequest.SendChunked = true;
                            //httpRequest.TransferEncoding = "UTF-8";
                            //if (httpRequest.CookieContainer == null) {
                            //    httpRequest.CookieContainer = container;
                            //}

                            //request.Method = "POST";
                            //request.Headers.Add("DNT", "1");
                            //request.Headers.Add("Accept-Encoding", "gzip, deflate");
                            //request.Headers.Add("Accept-Language", "en-US,en;q=0.8");
                            //request.Headers.Add("X-Requested-With", "XMLHttpRequest");
                            //request.Headers.Add("Origin", "http://www.septl.org");
                            //request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                            //request.ContentLength = postData.Length;


                            //Stream dataStream = request.GetRequestStream();
                            //dataStream.Write(postData, 0, postData.Length);
                            //dataStream.Close();
                            //WebResponse response = request.GetResponse();
                            //// Display the status.
                            //Console.WriteLine(((HttpWebResponse)response).StatusDescription);
                            //// Get the stream containing content returned by the server.
                            //dataStream = response.GetResponseStream();
                            //StreamReader reader = new StreamReader(dataStream);
                            //string responseFromServer = reader.ReadToEnd();
                            //Console.WriteLine(responseFromServer);
                            //reader.Close();
                            //dataStream.Close();
                            //response.Close();

                            //browser.Navigate(
                            //      url,
                            //      returnData,
                            //      postData,
                            //      additionalHeaders
                            //    );
                            #endregion

                            newCat.AddTool(new Tool {
                                id = id,
                                name = name,
                            });

                            // adding tool fields
                            HtmlElementCollection possibleFields = item.Parent.GetElementsByTagName("li");
                            foreach (HtmlElement field in possibleFields) {

                            }
                        }
                    }
                    categoriesParsed.Add(newCat);
                }
            }

            System.IO.File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads\\SETLTools.txt", JsonConvert.SerializeObject(browser.Document));
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
    }
}
