namespace CloneIntime.Entities;

public class GroupEntity
{
    public Guid Id { get; set; }
    public string Number { get; set; }
    public EdDirectionEntity Direction { get; set; }
    public string Name { get; set; }
}