using System.ComponentModel.DataAnnotations;

namespace CloneIntime.Models.DTO
{
    public class DayDTO
    {
        [Required]
        public DateTime Day { get; set; }
        public WeekEnum WeekDay { get; set; }
        [Required]
        public Int32 countClases { get; set; }
    }
}
