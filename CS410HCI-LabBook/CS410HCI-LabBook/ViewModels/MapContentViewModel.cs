using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace CS410HCI_LabBook.ViewModels {
    public class MapContentViewModel {
        public List<Section> Sections { get; set; }
        public string Search { get; set; }

        public MapContentViewModel() {
            Sections = new List<Section>();
            SetupData(); //
        }

        private void SetupData() {
            string path = AppDomain.CurrentDomain.BaseDirectory + "Content\\Recourse Documents\\SETLTools.txt";

            using (StreamReader reader = new StreamReader(path)) {
                dynamic jsonObj = JsonConvert.DeserializeObject(reader.ReadToEnd());

                int j = 0;
                foreach (dynamic obj in jsonObj) {
                    List<Tool> tools = new List<Tool>();

                    foreach (dynamic t in obj.Tools) {
                        tools.Add(new Tool() {
                            Id = (int)t.id,
                            Name = t.name,
                        });
                    }

                    Sections.Add(new Section() {
                        Id = ++j,
                        Name = obj.name,
                        ToolList = tools,
                    });
                }
            }   
        }
    }

    public class Section {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Tool> ToolList { get; set; }
    }

    public class Tool {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
