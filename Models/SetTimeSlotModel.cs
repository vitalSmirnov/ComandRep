using CloneIntime.Models.DTO;
using System.ComponentModel.DataAnnotations;

namespace CloneIntime.Models
{
    public class SetTimeSlotModel
    {
        [Required]
        public DateTime Date { get; set; }
        public UInt16 PairNumber { get; set; }
        public LessonTypeEnum Type { get; set; }
        [Required]
        public string Professor { get; set; }
        [Required]
        public List<string> Groups { get; set; }
        [Required]
        public string Discipline { get; set; }
        [Required]
        public string Audiroty { get; set; }

    }
}
