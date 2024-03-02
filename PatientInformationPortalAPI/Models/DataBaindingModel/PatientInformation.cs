using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PatientInformationPortalAPI.Enums;

namespace PatientInformationPortalAPI.Models.DataBaindingModel
{
    public class PatientInformation
    {
        [Key]
        public int PatientID { get; set; }
        [Required,MaxLength(30)]
        public string Name { get; set; }
        [Required]
        public int DiseaseID { get; set; }
        public EpilepsyStatus EpilepsyStatus { get; set; }
        public ICollection<NCDDetail> NCDDetails { get; set; }
        public ICollection<AllergiesDetail> AllergiesDetails { get; set; }
    }

}
