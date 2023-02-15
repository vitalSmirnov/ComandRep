namespace CloneIntime.Entities;

public class TimeSlotEntity : BaseEntity
{
    public PairEntity Pair { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; } //����� ������� ���� �� ������/��������� ( public DateOnly Date )
    public WeekEnum WeekDay { get; set; } // ������ ���� ����� ������� ������ (��.����), ������ ��� �������� ����� ��������
}