using System.ComponentModel.DataAnnotations;

namespace CloneIntime.Models.DTO
{
    public class FacultyDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Number { get; set; }
    }
}
