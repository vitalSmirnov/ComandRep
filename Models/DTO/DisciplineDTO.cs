using CloneIntime.Entities;
using System.ComponentModel.DataAnnotations;

namespace CloneIntime.Models.DTO
{
    public class DisciplineDTO : BaseEntity
    {
        public TeacherEntity Teacher { get; set; }

        [Required]
        public string Number { get; set; }
    }
}
