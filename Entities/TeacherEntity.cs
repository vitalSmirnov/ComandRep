namespace CloneIntime.Entities;

public class TeacherEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<GroupEntity> Groups { get; set; }
}