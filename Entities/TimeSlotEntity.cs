namespace CloneIntime.Entities;

public class TimeSlotEntity
{
    public Guid Id { get; set; }

    public PairEntity Pair { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
}