using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace PatientInformationPortalWeb.Models.ViewModels
{
    public class PatientInfoViewModel
    {
        public int PatientID { get; set; }

        [Required(ErrorMessage = "Please enter a patient name")]
        public string Name { get; set; }

        public int SelectedDiseaseInformation { get; set; }
        public SelectList? DiseaseInformationSelectList { get; set; }
        public int SelectedEpilepsyStatus { get; set; }
        public List<SelectListItem>? EpilepsyStatusSelectList { get; set; }
        public List<int>? SelectedLeftNCDs { get; set; }
        public SelectList? LeftNCDSelectList { get; set; }
        public List<int>? SelectedRightNCDs { get; set; }
        public SelectList? RightNCDSelectList { get; set; }
        public List<int>? SelectedLeftAllergies { get; set; }
        public SelectList? LeftAllergiesSelectList { get; set; }
        public List<int>? SelectedRightAllergies { get; set; }
        public SelectList? RightAllergiesSelectList { get; set; }
    }
}
