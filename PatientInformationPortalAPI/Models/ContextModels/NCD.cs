using System.ComponentModel.DataAnnotations;

namespace PatientInformationPortalAPI.Models.ContextModels
{
    public class NCD
    {

        [Key]
        public int NCDID { get; set; }
        [Required,MaxLength(30)]
        public string NCDName { get; set; }
    }
}
