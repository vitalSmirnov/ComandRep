namespace CloneIntime.Entities;

public class TimeSlotEntity : BaseEntity
{
    public PairEntity Pair { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; } //ћожно достать дату из начала/окончани€
    public WeekEnum WeekDay { get; set; } // кстати тоже можно достать оттуда (см.выше)
}