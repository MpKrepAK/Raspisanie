using System.ComponentModel.DataAnnotations.Schema;

namespace Raspisanie.Models.Database.Entitys;

public class MainSchedule
{
    public long Id { get; set; }
    [ForeignKey("TeacherSubject")]
    public long TeacherSubjectId { get; set; }
    public TeacherSubject? TeacherSubject { get; set; }
    [ForeignKey("Day")]
    public long DayId { get; set; }
    public Day? Day { get; set; }
    [ForeignKey("Cabinet")] 
    public long CabinetId { get; set; }
    public Cabinet? Cabinet { get; set; }
}