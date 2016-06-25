using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS410HCI_LabBook.ViewModels {
    public class LabProject2ViewModel {
        [Display(Name = "Patient Id")]
        public int PatientId { get; set; }

        [Display(Name = "Current Date/Time")]
        public DateTime CurrentDateTime { get; set; }

        public double Temperature { get; set; }
        public bool Celcius { get; set; }
        public bool Farenheit { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Pulse rate must be a positive number.")]
        public int Pulse { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Systolic rate must be a positive number.")]
        public int Systolic { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Diastolic rate must be a positive number.")]
        public int Diastolic { get; set; }

        [Display(Name = "Respiratory Rate")]
        [Range(0, int.MaxValue, ErrorMessage = "Respiratory rate must be a positive number.")]
        public int RespiratoryRate { get; set; }

        [Display(Name = "Pain Level")]
        [Range(0,10, ErrorMessage = "Pain level must be a number in between 0 and 10.")]
        public int PainLevel { get; set; }

        [Display(Name = "Oxygen Saturation")]
        [Range(0, 1, ErrorMessage = "Oxygen saturation may not exceed 100%.")]
        public double OxygenSaturation { get; set; }

        [Display(Name = "Blood Glucose Level")]
        [Range(0, int.MaxValue, ErrorMessage = "Blood glucose level must be a positive number.")]
        public int BloodGlucoseLevel { get; set; }


        public LabProject2ViewModel() {
            this.CurrentDateTime = DateTime.Now;
        }
    }
}
