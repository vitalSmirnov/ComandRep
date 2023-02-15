namespace CloneIntime.Entities;

public class TimeSlotEntity : BaseEntity
{
    public PairEntity Pair { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; } //Можно достать дату из начала/окончания ( public DateOnly Date )
    public WeekEnum WeekDay { get; set; } // кстати тоже можно достать оттуда (см.выше), однако для удобства можно оставить
}