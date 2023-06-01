using Microsoft.EntityFrameworkCore;
using Raspisanie.Models.Database.Entitys;
using Raspisanie.Models.Database.Repositories.Interfaces;

namespace Raspisanie.Models.Database.Repositories.Implementations;

public class MainScheduleRepository : IRepository<MainSchedule>
{
    private readonly RaspisanieContext _context;
    public MainScheduleRepository(RaspisanieContext context)
    {
        _context = context;
    }
    public async Task<List<MainSchedule>> GetAll()
    {
        return await _context.MainSchedules.ToListAsync();
    }

    public async Task<MainSchedule> GetById(long id)
    {
        return await _context.MainSchedules.FirstOrDefaultAsync(x=>x.Id==id);
    }

    public async Task<MainSchedule> Update(long id, MainSchedule entity)
    {
        var entityById = await _context.MainSchedules.FirstOrDefaultAsync(x => x.Id == id);
        entityById.DayId = entity.DayId;
        entityById.TeacherSubjectId = entity.TeacherSubjectId;
        entityById.Number = entity.Number;
        entityById.CabinetId = entity.CabinetId;
        await _context.SaveChangesAsync();
        return entityById;
    }

    public async Task<MainSchedule> Delete(long id)
    {
        var entityById = await _context.MainSchedules.FirstOrDefaultAsync(x => x.Id == id);
        _context.MainSchedules.Remove(entityById);
        await _context.SaveChangesAsync();
        return entityById;
    }

    public async Task<MainSchedule> Add(MainSchedule entity)
    {
        _context.MainSchedules.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}