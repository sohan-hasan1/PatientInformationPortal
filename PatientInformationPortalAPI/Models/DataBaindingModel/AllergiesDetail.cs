using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientInformationPortalAPI.Models.DataBaindingModel
{
    public class AllergiesDetail
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int PatientID { get; set; }
        [Required]
        public int AllergiesID { get; set; }
    }
}
