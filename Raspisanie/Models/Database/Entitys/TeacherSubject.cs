using System.ComponentModel.DataAnnotations.Schema;

namespace Raspisanie.Models.Database.Entitys;

public class TeacherSubject
{
    public long Id { get; set; }
    [ForeignKey("Subject")]
    public long SubjectId { get; set; }
    public Subject? Subject { get; set; }
    [ForeignKey("Subgroup")]
    public long SubgroupId { get; set; }
    public Subgroup? Subgroup { get; set; }
    [ForeignKey("Teacher")]
    public long TeacherId { get; set; }
    public Teacher? Teacher { get; set; }
    public List<DaySchedule>? DaySchedules { get; set; }
    public List<MainSchedule>? MainSchedules { get; set; }
}