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
    public async Task<IActionResult> MainFill()
    {
        try
        {
            await FillGroups();
            await FillSubject();
            await FillSubgroup();
            await FillTeacher();
            await FillTeacherSubject();
            await FillGroupSubjectTime();
            await FillDay();
            await FillDate();
            await Task.Delay(2000);
            await FillCabinets();
            await FillMainSchedule();
            await FillDaySchedule();
            await FillReplacementTeacher();
            return new OkResult();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new BadRequestResult();
        }
    }

    private async Task FillGroups()
    {
        for (int i = 0; i < 10; i++)
        {
            await _group.Add(new Group()
            {
                Name = $"группа{i + 1}"
            });
        }
    }
    
    private async Task FillSubject()
    {
        IList<string> list = new List<string>();
        list.Add("Труд");
        list.Add("Математика");
        list.Add("Природоведение");
        list.Add("Физкультура");
        list.Add("Русский язык");
        list.Add("Биология");
        list.Add("География");
        list.Add("Литература");
        list.Add("История");
        list.Add("Черчение");
        list.Add("Алгебра");
        list.Add("Геометрия");
        list.Add("Химия");
        list.Add("Физика");
        list.Add("Естествознание");
        list.Add("Экология");
        list.Add("Иностранный язык");
        list.Add("Чтение");
        list.Add("Чистописание");
        list.Add("Родной язык");
        
        foreach (var predmet in list)
        {
            await _subject.Add(new Subject()
            {
                Name = predmet
            });
        }
    }
    
    private async Task FillSubgroup()
    {
        var groups =  await _group.GetAll();
        foreach (var group in groups)
        {
            await _subgroup.Add(new Subgroup()
            {
                Name = $"1",
                GroupId = group.Id
            });
            await _subgroup.Add(new Subgroup()
            {
                Name = $"2",
                GroupId = group.Id
            });
        }
    }

    private async Task FillTeacher()
    {
        IList<string> list = new List<string>();
        list.Add("Сергеев Осип Лукьянович");
        list.Add("Голубев Анатолий Валерьевич");
        list.Add("Кудряшов Митрофан Игоревич");
        list.Add("Панов Святослав Пантелеймонович");
        list.Add("Воронцов Любомир Тарасович");
        list.Add("Крылов Глеб Аристархович");
        list.Add("Калашников Ипполит Вадимович");
        list.Add("Смирнов Агафон Якунович");
        list.Add("Алексеев Степан Яковлевич");
        list.Add("Маслов Любовь Кириллович");
        foreach (var item in list)
        {
            var fio = item.Split(" ");
            await _teacher.Add(new Teacher()
            {
                LastName = fio[0],
                FirstName = fio[1],
                SurName = fio[2]
            });
        }
    }
    
    private async Task FillTeacherSubject()
    {
        var teachers = await _teacher.GetAll();
        var subjects = await _subject.GetAll();
        var subGroup = await _subgroup.GetAll();
        
        int i = 0;
        
        foreach (var item in teachers)
        {
            await _teacherSubject.Add(new TeacherSubject()
            {
                SubjectId = subjects[i].Id,
                SubgroupId = subGroup[i].Id,
                TeacherId = item.Id
            });
            
            i++;
            
            await _teacherSubject.Add(new TeacherSubject()
            {
                SubjectId = subjects[i].Id,
                SubgroupId = subGroup[i].Id,
                TeacherId = item.Id
            });

            i++;
        }
    }
    
    private async Task FillGroupSubjectTime()
    {
        var list =  await _subgroup.GetAll();
        foreach (var subject in await _subject.GetAll())
        {
            foreach (var subgroup in list)
            {
                await _groupSubjectTime.Add(new GroupSubjectTime()
                {
                    PassedTime = 0,
                    TotalTime = new Random().Next(100,200),
                    SubgroupId = subgroup.Id,
                    SubjectId = subject.Id
                });
            }
        }
    }
    
    private async Task FillDay()
    {
        await _day.Add(new Day()
        {
            Name = "Понедельник"
        });
        await _day.Add(new Day()
        {
            Name = "Вторник"
        });
        await _day.Add(new Day()
        {
            Name = "Среда"
        });
        await _day.Add(new Day()
        {
            Name = "Четверг"
        });
        await _day.Add(new Day()
        {
            Name = "Пятница"
        });
        await _day.Add(new Day()
        {
            Name = "Суббота"
        });
        await _day.Add(new Day()
        {
            Name = "Воскресенье"
        });
    }
    
    private async Task FillDate()
    {
        await _date.Add(new Date()
        {
            DateValue = new DateOnly(2023,05,29)
        });
        await _date.Add(new Date()
        {
            DateValue = new DateOnly(2023,05,30)
        });
        await _date.Add(new Date()
        {
            DateValue = new DateOnly(2023,05,31)
        });
        await _date.Add(new Date()
        {
            DateValue = new DateOnly(2023,06,01)
        });
        await _date.Add(new Date()
        {
            DateValue = new DateOnly(2023,06,02)
        });
        await _date.Add(new Date()
        {
            DateValue = new DateOnly(2023,06,03)
        });
    }
    
    private async Task FillCabinets()
    {
        for (int i = 0; i < 30; i++)
        {
            await _cabinet.Add(new Cabinet()
            {
                Number = i + 1
            });
        }
    }

    private async Task FillMainSchedule()
    {
        var teacherSubjects = await _teacherSubject.GetAll();
        var cabinets = await _cabinet.GetAll();
        var days = await _day.GetAll();
    
        await _mainSchedule.Add(new MainSchedule()
        {
            TeacherSubjectId = teacherSubjects[0].Id,
            CabinetId = cabinets[0].Id,
            DayId = days[0].Id
        });
        await _mainSchedule.Add(new MainSchedule()
        {
            TeacherSubjectId = teacherSubjects[0].Id,
            CabinetId = cabinets[0].Id,
            DayId = days[0].Id
        });
        await _mainSchedule.Add(new MainSchedule()
        {
            TeacherSubjectId = teacherSubjects[1].Id,
            CabinetId = cabinets[1].Id,
            DayId = days[0].Id
        });
        await _mainSchedule.Add(new MainSchedule()
        {
            TeacherSubjectId = teacherSubjects[2].Id,
            CabinetId = cabinets[2].Id,
            DayId = days[0].Id
        });
        await _mainSchedule.Add(new MainSchedule()
        {
            TeacherSubjectId = teacherSubjects[3].Id,
            CabinetId = cabinets[3].Id,
            DayId = days[0].Id
        });
    }
    
    private async Task FillDaySchedule()
    {
        var teacherSubjects = await _teacherSubject.GetAll();
        var cabinets = await _cabinet.GetAll();
        var dates = await _date.GetAll();
    
        await _mainSchedule.Add(new MainSchedule()
        {
            TeacherSubjectId = teacherSubjects[0].Id,
            CabinetId = cabinets[0].Id,
            DayId = dates[0].Id
        });
        await _daySchedule.Add(new DaySchedule()
        {
            TeacherSubjectId = teacherSubjects[2].Id,
            CabinetId = cabinets[2].Id,
            DateId = dates[0].Id
        });
    }
    
    private async Task FillReplacementTeacher()
    {
        var teacherSubjects = await _teacherSubject.GetAll();
        var cabinets = await _cabinet.GetAll();
        var dates = await _date.GetAll();
    
        await _mainSchedule.Add(new MainSchedule()
        {
            TeacherSubjectId = teacherSubjects[0].Id,
            CabinetId = cabinets[0].Id,
            DayId = dates[0].Id
        });
        await _daySchedule.Add(new DaySchedule()
        {
            TeacherSubjectId = teacherSubjects[2].Id,
            CabinetId = cabinets[2].Id,
            DateId = dates[0].Id
        });
    }
}