namespace CloneIntime.Entities;

public class EdDirectionEntity
{
    public Guid Id { get; set; }
    public Int32 Number { get; set; }
    public string Name { get; set; }
    public FacultyEntity Faculty { get; set; }
}