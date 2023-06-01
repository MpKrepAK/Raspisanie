using System.ComponentModel.DataAnnotations.Schema;

namespace Raspisanie.Models.Database.Entitys;

public class Date
{
    public long Id { get; set; }
    [Column(name:"date")]
    public DateOnly DateValue { get; set; }
    public List<DaySchedule>? DaySchedules { get; set; }
}