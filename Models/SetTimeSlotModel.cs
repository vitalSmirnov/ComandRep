using CloneIntime.Models.DTO;
using System.ComponentModel.DataAnnotations;

namespace CloneIntime.Models
{
    public class SetTimeSlotModel
    {
        [Required]
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public LessonTypeEnum Type { get; set; }
        [Required]
        public string Professor { get; set; }
        [Required]
        public List<string> Groups { get; set; }
        [Required]
        public string Discipline { get; set; }
        [Required]
        public Int32 Audiroty { get; set; }

    }
}
