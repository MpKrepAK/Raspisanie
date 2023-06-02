using Microsoft.EntityFrameworkCore;
using Raspisanie.Models.Database.Entitys;
using Raspisanie.Models.Database.Repositories.Interfaces;

namespace Raspisanie.Models.Database.Repositories.Implementations;

public class SubjectRepository : IRepository<Subject>
{
    private readonly RaspisanieContext _context;
    public SubjectRepository(RaspisanieContext context)
    {
        _context = context;
    }
    public async Task<List<Subject>> GetAll()
    {
        return await _context.Subjects
            .Include(x=>x.TeacherSubjects)
            .Include(x=>x.GroupSubjectTimes)
            .ToListAsync();
    }

    public async Task<Subject> GetById(long id)
    {
        return await _context.Subjects
            .Include(x=>x.TeacherSubjects)
            .Include(x=>x.GroupSubjectTimes)
            .FirstOrDefaultAsync(x=>x.Id==id);
    }

    public async Task<Subject> Update(long id, Subject entity)
    {
        var entityById = await _context.Subjects.FirstOrDefaultAsync(x => x.Id == id);
        entityById.Name = entity.Name;
        await _context.SaveChangesAsync();
        return entityById;
    }

    public async Task<Subject> Delete(long id)
    {
        var entityById = await _context.Subjects.FirstOrDefaultAsync(x => x.Id == id);
        _context.Subjects.Remove(entityById);
        await _context.SaveChangesAsync();
        return entityById;
    }

    public async Task<Subject> Add(Subject entity)
    {
        _context.Subjects.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}