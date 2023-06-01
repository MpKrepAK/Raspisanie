using Microsoft.AspNetCore.Mvc;
using Raspisanie.Models.Database.Entitys;
using Raspisanie.Models.Database.Repositories.Interfaces;

namespace Raspisanie.Controllers.Other;

[ApiController]
[Route("fill")]
public class FillController : ControllerBase
{
    private readonly IRepository<Cabinet> _cabinet;
    private readonly IRepository<Date> _date;
    private readonly IRepository<Day> _day;
    private readonly IRepository<DaySchedule> _daySchedule;
    private readonly IRepository<Group> _group;
    private readonly IRepository<GroupSubjectTime> _groupSubjectTime;
    private readonly IRepository<MainSchedule> _mainSchedule;
    private readonly IRepository<ReplacementTeacher> _replacementTeacher;
    private readonly IRepository<Subgroup> _subgroup;
    private readonly IRepository<Subject> _subject;
    private readonly IRepository<Teacher> _teacher;
    private readonly IRepository<TeacherSubject> _teacherSubject;
    
    public FillController(IRepository<Cabinet> cabinet,
        IRepository<Date> date,
        IRepository<Day> day,
        IRepository<DaySchedule> daySchedule,
        IRepository<Group> group,
        IRepository<GroupSubjectTime> groupSubjectTime,
        IRepository<MainSchedule> mainSchedule,
        IRepository<ReplacementTeacher> replacementTeacher,
        IRepository<Subgroup> subgroup,
        IRepository<Subject> subject,
        IRepository<Teacher> teacher,
        IRepository<TeacherSubject> teacherSubject)
    {
        _cabinet = cabinet;
        _day = day;
        _daySchedule = daySchedule;
        _group = group;
        _groupSubjectTime = groupSubjectTime;
        _mainSchedule = mainSchedule;
        _replacementTeacher = replacementTeacher;
        _subgroup = subgroup;
        _subject = subject;
        _teacher = teacher;
        _teacherSubject = teacherSubject;
        _date = date;
    }

    [HttpGet]
    public IActionResult MainFill()
    {
        try
        {
            FillGroups();
            return new OkResult();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new BadRequestResult();
        }
    }

    private void FillGroups()
    {
        for (int i = 0; i < 5; i++)
        {
            _group.Add(new Group()
            {
                Name = $"группа{i + 1}"
            });
        }
    }
}