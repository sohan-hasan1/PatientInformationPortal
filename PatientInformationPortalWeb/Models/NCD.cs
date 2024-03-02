using System.ComponentModel.DataAnnotations;

namespace PatientInformationPortalWeb.Models
{
    public class NCD
    {

        [Key]
        public int NCDID { get; set; }
        [Required,MaxLength(30)]
        public string NCDName { get; set; }
    }
}
