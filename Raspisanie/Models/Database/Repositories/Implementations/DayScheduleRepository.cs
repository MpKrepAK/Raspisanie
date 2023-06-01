using Microsoft.EntityFrameworkCore;
using Raspisanie.Models.Database.Entitys;
using Raspisanie.Models.Database.Repositories.Interfaces;

namespace Raspisanie.Models.Database.Repositories.Implementations;

public class DayScheduleRepository : IRepository<DaySchedule>
{
    private readonly RaspisanieContext _context;
    public DayScheduleRepository(RaspisanieContext context)
    {
        _context = context;
    }
    public async Task<List<DaySchedule>> GetAll()
    {
        return await _context.DaySchedules.ToListAsync();
    }

    public async Task<DaySchedule> GetById(long id)
    {
        return await _context.DaySchedules.FirstOrDefaultAsync(x=>x.Id==id);
    }

    public async Task<DaySchedule> Update(long id, DaySchedule entity)
    {
        var entityById = await _context.DaySchedules.FirstOrDefaultAsync(x => x.Id == id);
        entityById.CabinetId = entity.CabinetId;
        entityById.DateId = entity.DateId;
        entityById.TeacherSubjectId = entity.TeacherSubjectId;
        await _context.SaveChangesAsync();
        return entityById;
    }

    public async Task<DaySchedule> Delete(long id)
    {
        var entityById = await _context.DaySchedules.FirstOrDefaultAsync(x => x.Id == id);
        _context.DaySchedules.Remove(entityById);
        await _context.SaveChangesAsync();
        return entityById;
    }

    public async Task<DaySchedule> Add(DaySchedule entity)
    {
        _context.DaySchedules.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}