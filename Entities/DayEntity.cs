namespace CloneIntime.Entities;

public class DayEntity
{
    public Guid Id { get; set; }
    public WeekEnum DayName { get; set; }
    public DateTime Date { get; set; }
    public GroupEntity Group { get; set; }
    public List<TimeSlotEntity> Lessons { get; set; }
}   