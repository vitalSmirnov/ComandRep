namespace CloneIntime.Entities;

public class DisciplineEntity : BaseEntity
{
    public string Name { get; set; }
    public List<TeacherEntity> Teachers { get; set; }
    public List<GroupEntity> Groups { get; set; }
}