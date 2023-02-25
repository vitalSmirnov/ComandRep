namespace CloneIntime.Entities;

public class TeacherEntity : BaseEntity
{
    public string Name { get; set; }
    public List<DisciplineEntity> Disciplines { get; set; }
}