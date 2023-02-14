namespace CloneIntime.Entities;

public class DisciplineEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public LessonTypeEnum Type { get; set; }
}