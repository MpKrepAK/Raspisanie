namespace Raspisanie.Models.Database.Entitys;

public class Day
{
    public long Id { get; set; }
    public string Name { get; set; }
    public List<MainSchedule>? MainSchedules { get; set; }
}