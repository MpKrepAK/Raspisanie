using System.ComponentModel.DataAnnotations.Schema;

namespace Raspisanie.Models.Database.Entitys;

public class Subgroup
{
    public long Id { get; set; }
    [ForeignKey("Group")] 
    public long? GroupId { get; set; }
    public Group? Group { get; set; }
    public string Name { get; set; }
    public List<Day>? Days { get; set; }
    public List<Date>? Dates { get; set; }
    public List<GroupSubjectTime>? GroupSubjectTimes { get; set; }
    public List<TeacherSubject>? TeacherSubjects { get; set; }
}