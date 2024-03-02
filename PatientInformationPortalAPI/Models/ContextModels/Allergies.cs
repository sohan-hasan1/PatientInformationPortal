using System.ComponentModel.DataAnnotations;

namespace PatientInformationPortalAPI.Models.ContextModels
{
    public class Allergies
    {
        [Key]
        public int AllergiesID { get; set; }

        [Required, MaxLength(30)]
        public string AllergiesName { get; set; }
    }
}
