using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientInformationPortalWeb.Models
{
    public class NCDDetail
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int PatientID { get; set; }
        [Required]
        public int NCDID { get; set; }
        [ForeignKey("PatientID")]
        public virtual PatientInformation PatientInformation { get; set; }
        [ForeignKey("NCDID")]
        public virtual NCD NCD { get; set; }

    }
}
