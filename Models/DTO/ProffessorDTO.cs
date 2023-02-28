using System.ComponentModel.DataAnnotations;

namespace CloneIntime.Models.DTO
{
    public class ProffessorDTO
    {
        [Required]

        public Guid id { get; set; }
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
