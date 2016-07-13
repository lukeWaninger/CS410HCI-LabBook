using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS410HCI_LabBook.ViewModels {
    public class MapContentViewModel {
        public List<Section> Sections { get; set; }
        public string Search { get; set; }

        public MapContentViewModel() {
            SetupData();
        }

        private void SetupData() {
            this.Sections = new List<Section>() {
                new Section {
                    Id =  1,
                    Name = "Rakes/Weed Whackers",
                    ToolList = new List<Tool>() {
                        new Tool { Id = 1, Name = "A rake" },
                        new Tool { Id = 2, Name = "A weed whacker" },
                    }
                },
                new Section {
                    Id = 2,
                    Name = "Shovels",
                    ToolList = new List<Tool>() {
                        new Tool { Id = 3, Name = "A shovel" },
                        new Tool { Id = 4, Name = "Another shovel" },
                    },
                },
                new Section {
                    Id = 3,
                    Name = "Pry Bars",
                    ToolList = new List<Tool> {
                        new Tool { Id = 5, Name = "A pry bar" }
                    }
                }
           };
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
