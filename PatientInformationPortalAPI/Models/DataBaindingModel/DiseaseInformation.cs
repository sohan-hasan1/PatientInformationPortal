using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace PatientInformationPortalAPI.Models.DataBaindingModel
{
    public class DiseaseInformation
    {
        [Key]
        public int DiseaseID { get; set; }
        [Required,MaxLength(30)]
        public string DiseaseName { get; set; }

    }
}
