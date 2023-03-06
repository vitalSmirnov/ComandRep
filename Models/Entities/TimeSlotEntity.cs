namespace CloneIntime.Entities;

public class TimeSlotEntity : BaseEntity
{
    public List<PairEntity> Pair { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; } //ћожно достать дату из начала/окончани€ ( public DateOnly Date )
    public WeekEnum WeekDay { get; set; } //  стати тоже можно достать оттуда (см.выше), однако дл€ удобства можно оставить
}