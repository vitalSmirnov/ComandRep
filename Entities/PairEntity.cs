namespace CloneIntime.Entities;

public class PairEntity
{
    public Guid Id { get; set; }
    public DisciplineEntity Discipline { get; set; }
    public GroupEntity Group { get; set; }
    public TeacherEntity Teacher { get; set; }
    public AuditoryEntity Auditory { get; set; }
}