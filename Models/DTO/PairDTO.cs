using System.ComponentModel.DataAnnotations;

namespace CloneIntime.Models.DTO
{
    public class PairDTO
    {
        [Required]
        public LessonTypeEnum LessonType { get; set; }
        [Required]
        public string Proffessor { get; set; }
        [Required]
        public List<GroupDTO> Groups { get; set; }
        [Required]
        public string Discipline { get; set; }
        [Required]
        public string Audiroty { get; set; }
    }
}
