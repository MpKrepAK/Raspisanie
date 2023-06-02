using System.ComponentModel.DataAnnotations.Schema;

namespace Raspisanie.Models.Database.Entitys;

public class ReplacementTeacher
{
    public long Id { get; set; }
    [ForeignKey("Teacher")]
    public long TeacherId { get; set; }
    public Teacher? Teacher { get; set; }
    [ForeignKey("DaySchedule")]
    public long? DayScheduleId { get; set; }
    public DaySchedule? DaySchedule { get; set; }
}