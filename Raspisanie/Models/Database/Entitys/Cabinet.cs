namespace Raspisanie.Models.Database.Entitys;

public class Cabinet
{
    public long Id { get; set; }
    public int Number { get; set; }
    public List<MainSchedule>? MainSchedules { get; set; }
    public List<DaySchedule>? DaySchedules { get; set; }
}