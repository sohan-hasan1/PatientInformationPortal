using System.ComponentModel.DataAnnotations;

namespace PatientInformationPortalWeb.Models
{
    public class Allergies
    {
        [Key]
        public int AllergiesID { get; set; }

        [Required, MaxLength(30)]
        public string AllergiesName { get; set; }
    }
}
