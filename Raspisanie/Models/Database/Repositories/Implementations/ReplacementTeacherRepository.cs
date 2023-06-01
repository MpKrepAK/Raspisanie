using Microsoft.EntityFrameworkCore;
using Raspisanie.Models.Database.Entitys;
using Raspisanie.Models.Database.Repositories.Interfaces;

namespace Raspisanie.Models.Database.Repositories.Implementations;

public class ReplacementTeacherRepository : IRepository<ReplacementTeacher>
{
    private readonly RaspisanieContext _context;
    public ReplacementTeacherRepository(RaspisanieContext context)
    {
        _context = context;
    }
    public async Task<List<ReplacementTeacher>> GetAll()
    {
        return await _context.ReplacementTeachers.ToListAsync();
    }

    public async Task<ReplacementTeacher> GetById(long id)
    {
        return await _context.ReplacementTeachers.FirstOrDefaultAsync(x=>x.Id==id);
    }

    public async Task<ReplacementTeacher> Update(long id, ReplacementTeacher entity)
    {
        var entityById = await _context.ReplacementTeachers.FirstOrDefaultAsync(x => x.Id == id);
        entityById.DayScheduleId = entity.DayScheduleId;
        entityById.TeacherId = entity.TeacherId;
        await _context.SaveChangesAsync();
        return entityById;
    }

    public async Task<ReplacementTeacher> Delete(long id)
    {
        var entityById = await _context.ReplacementTeachers.FirstOrDefaultAsync(x => x.Id == id);
        _context.ReplacementTeachers.Remove(entityById);
        await _context.SaveChangesAsync();
        return entityById;
    }

    public async Task<ReplacementTeacher> Add(ReplacementTeacher entity)
    {
        _context.ReplacementTeachers.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}