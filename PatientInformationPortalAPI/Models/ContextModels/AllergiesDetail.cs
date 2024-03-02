using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientInformationPortalAPI.Models.ContextModels
{
    public class AllergiesDetail
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int PatientID { get; set; }
        [Required]
        public int AllergiesID { get; set; }
        [ForeignKey("PatientID")]
        public virtual PatientInformation? PatientInformation { get; set; }
        [ForeignKey("AllergiesID")]
        public virtual Allergies? Allergies { get; set; }
    }
}
