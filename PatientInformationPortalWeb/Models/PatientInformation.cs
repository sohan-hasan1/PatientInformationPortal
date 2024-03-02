using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PatientInformationPortalWeb.Enums;

namespace PatientInformationPortalWeb.Models
{
    public class PatientInformation
    {
        [Key]
        public int PatientID { get; set; }
        [Required,MaxLength(30)]
        public string Name { get; set; }
        [Required]
        public int DiseaseID { get; set; }
        [ForeignKey("DiseaseID")]
        public EpilepsyStatus EpilepsyStatus { get; set; }
        public DiseaseInformation? DiseaseInformation { get; set; } 
        public ICollection<NCDDetail>? NCDDetails { get; set; }
        public ICollection<AllergiesDetail>? AllergiesDetails { get; set; }
    }

}
