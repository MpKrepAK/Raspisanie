namespace Raspisanie.Models.Database.Entitys;

public class Subject
{
    public long Id { get; set; }
    public string Name { get; set; }
    public List<GroupSubjectTime>? GroupSubjectTimes { get; set; }
    public List<TeacherSubject>? TeacherSubjects { get; set; }
}