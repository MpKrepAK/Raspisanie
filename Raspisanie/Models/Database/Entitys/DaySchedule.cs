using System.ComponentModel.DataAnnotations.Schema;

namespace Raspisanie.Models.Database.Entitys;

public class DaySchedule
{
    public long Id { get; set; }
    [ForeignKey("TeacherSubject")]
    public long TeacherSubjectId { get; set; }
    public TeacherSubject? TeacherSubject { get; set; }
    [ForeignKey("Cabinet")]
    public long CabinetId { get; set; }
    public Cabinet? Cabinet { get; set; }
    [ForeignKey("Date")]
    public long DateId { get; set; }
    public Date? Date { get; set; }
    [ForeignKey("ReplacementTeacher")]
    public long? ReplacementTeacherId { get; set; }
    public ReplacementTeacher? ReplacementTeacher { get; set; }
}