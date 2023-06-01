namespace Raspisanie.Models.Database.Entitys;

public class Group
{
    public long Id { get; set; }
    public string Name { get; set; }
    public List<Subgroup>? Subgroups { get; set; }
}