using Microsoft.EntityFrameworkCore;
using Raspisanie.Models.Database.Entitys;
using Raspisanie.Models.Database.Repositories.Interfaces;

namespace Raspisanie.Models.Database.Repositories.Implementations;

public class TeacherSubjectRepository : IRepository<TeacherSubject>
{
    private readonly RaspisanieContext _context;
    public TeacherSubjectRepository(RaspisanieContext context)
    {
        _context = context;
    }
    public async Task<List<TeacherSubject>> GetAll()
    {
        return await _context.TeacherSubjects.ToListAsync();
    }

    public async Task<TeacherSubject> GetById(long id)
    {
        return await _context.TeacherSubjects.FirstOrDefaultAsync(x=>x.Id==id);
    }

    public async Task<TeacherSubject> Update(long id, TeacherSubject entity)
    {
        var entityById = await _context.TeacherSubjects.FirstOrDefaultAsync(x => x.Id == id);
        entityById.SubjectId = entity.SubjectId;
        entityById.SubgroupId = entity.SubgroupId;
        await _context.SaveChangesAsync();
        return entityById;
    }

    public async Task<TeacherSubject> Delete(long id)
    {
        var entityById = await _context.TeacherSubjects.FirstOrDefaultAsync(x => x.Id == id);
        _context.TeacherSubjects.Remove(entityById);
        await _context.SaveChangesAsync();
        return entityById;
    }

    public async Task<TeacherSubject> Add(TeacherSubject entity)
    {
        _context.TeacherSubjects.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}