using System.ComponentModel.DataAnnotations;

namespace CloneIntime.Models.DTO
{
    public class DayDTO
    {
        public WeekEnum WeekDay { get; set; }
        public Int32 countClases { get; set; }
        public List<TimeSlotDTO> timeSlotDTOs { get; set; }

    }
}
