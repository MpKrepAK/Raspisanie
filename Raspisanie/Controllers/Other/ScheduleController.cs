using Microsoft.AspNetCore.Mvc;
using Raspisanie.Models.Database.Entitys;
using Raspisanie.Models.Database.Repositories.Interfaces;

namespace Raspisanie.Controllers.Other;

[ApiController]
[Route("schedule")]
public class ScheduleController : ControllerBase
{
    private readonly IRepository<MainSchedule> _mainSchedule;
    private readonly IRepository<TeacherSubject> _teacherSubject;
    public ScheduleController(
        IRepository<MainSchedule> mainSchedule,
        IRepository<TeacherSubject> teacherSubject)
    {
        _mainSchedule = mainSchedule;
        _teacherSubject = teacherSubject;
    }
    
    [HttpGet("main/{id}/{day}")]
    public async Task<IActionResult> MainSchedule(long id, int day)
    {
        Console.WriteLine(id);
        var main = await _mainSchedule.GetAll();
        return new OkObjectResult(main.Where(x=>x.DayId==day).Where(x=>x.TeacherSubject.Subgroup.GroupId==id));
    }
    
    // [HttpGet("main/{id}/{day}/{month}/{year}")]
    // public async Task<IActionResult> MainSchedule(long id, int day, int month, int year)
    // {
    //     Console.WriteLine(id);
    //     DateOnly dateOnly = new DateOnly(year,month,day);
    //     Console.WriteLine(dateOnly.ToLongDateString());
    //     var main = await _mainSchedule.GetAll();
    //     var subjects = await _teacherSubject.GetAll();
    //     var one = subjects.FirstOrDefault(x=>x.)
    //     return new OkObjectResult(main.Where(x=>x.));
    // }
}