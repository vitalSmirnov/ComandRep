using CloneIntime.Entities;
using System.ComponentModel.DataAnnotations;

namespace CloneIntime.Models.DTO
{
    public class TimeSlotDTO
    {
        [Required]
        public Int32 SlotNumber { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public PairDTO? Pair { get; set; }
    }
}
