using System.ComponentModel.DataAnnotations;

namespace CloneIntime.Models.DTO
{
    public class PairDTO
    {
        public LessonTypeEnum LessonType { get; set; }
        public string Proffessor { get; set; }
        public List<GroupDTO> Groups { get; set; }
        public Int32 Audiroty { get; set; }
    }
}
