namespace Raspisanie.Models.Database.Entitys;

public class Teacher
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string SurName { get; set; }
    public List<TeacherSubject>? TeacherSubject { get; set; }
    public List<ReplacementTeacher>? ReplacementTeachers { get; set; }
}