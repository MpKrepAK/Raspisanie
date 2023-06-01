using Microsoft.EntityFrameworkCore;
using Raspisanie.Models.Database.Entitys;
using Raspisanie.Models.Database.Repositories.Interfaces;

namespace Raspisanie.Models.Database.Repositories.Implementations;

public class TeacherRepository : IRepository<Teacher>
{
    private readonly RaspisanieContext _context;
    public TeacherRepository(RaspisanieContext context)
    {
        _context = context;
    }
    public async Task<List<Teacher>> GetAll()
    {
        return await _context.Teachers.ToListAsync();
    }

    public async Task<Teacher> GetById(long id)
    {
        return await _context.Teachers.FirstOrDefaultAsync(x=>x.Id==id);
    }

    public async Task<Teacher> Update(long id, Teacher entity)
    {
        var entityById = await _context.Teachers.FirstOrDefaultAsync(x => x.Id == id);
        entityById.FirstName = entity.FirstName;
        entityById.LastName = entity.LastName;
        entityById.SurName = entity.SurName;
        await _context.SaveChangesAsync();
        return entityById;
    }

    public async Task<Teacher> Delete(long id)
    {
        var entityById = await _context.Teachers.FirstOrDefaultAsync(x => x.Id == id);
        _context.Teachers.Remove(entityById);
        await _context.SaveChangesAsync();
        return entityById;
    }

    public async Task<Teacher> Add(Teacher entity)
    {
        _context.Teachers.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}