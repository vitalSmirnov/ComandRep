namespace CloneIntime.Entities;

public class TimeSlotEntity : BaseEntity
{
    public List<PairEntity> Pair { get; set; }
    public DayEntity Day { get; set; }
    public DateTime? Date { get; set; }
}