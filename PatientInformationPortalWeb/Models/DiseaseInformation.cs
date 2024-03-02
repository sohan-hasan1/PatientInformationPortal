using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace PatientInformationPortalWeb.Models
{
    public class DiseaseInformation
    {
        [Key]
        public int DiseaseID { get; set; }
        [Required,MaxLength(30)]
        public string DiseaseName { get; set; }
        public ICollection<PatientInformation> PatientInformations { get; set; }

    }
}
