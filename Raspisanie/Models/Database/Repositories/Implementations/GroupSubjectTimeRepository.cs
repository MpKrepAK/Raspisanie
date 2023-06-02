using Microsoft.EntityFrameworkCore;
using Raspisanie.Models.Database.Entitys;
using Raspisanie.Models.Database.Repositories.Interfaces;

namespace Raspisanie.Models.Database.Repositories.Implementations;

public class GroupSubjectTimeRepository : IRepository<GroupSubjectTime>
{
    private readonly RaspisanieContext _context;
    public GroupSubjectTimeRepository(RaspisanieContext context)
    {
        _context = context;
    }
    public async Task<List<GroupSubjectTime>> GetAll()
    {
        return await _context.GroupSubjectTimes
            .Include(x=>x.Subgroup)
            .Include(x=>x.Subject)
            .ToListAsync();
    }

    public async Task<GroupSubjectTime> GetById(long id)
    {
        return await _context.GroupSubjectTimes
            .Include(x=>x.Subgroup)
            .Include(x=>x.Subject)
            .FirstOrDefaultAsync(x=>x.Id==id);
    }

    public async Task<GroupSubjectTime> Update(long id, GroupSubjectTime entity)
    {
        var entityById = await _context.GroupSubjectTimes.FirstOrDefaultAsync(x => x.Id == id);
        entityById.SubjectId = entity.SubjectId;
        entityById.PassedTime = entity.PassedTime;
        entityById.TotalTime = entity.TotalTime;
        entityById.SubgroupId = entity.SubgroupId;
        await _context.SaveChangesAsync();
        return entityById;
    }

    public async Task<GroupSubjectTime> Delete(long id)
    {
        var entityById = await _context.GroupSubjectTimes.FirstOrDefaultAsync(x => x.Id == id);
        _context.GroupSubjectTimes.Remove(entityById);
        await _context.SaveChangesAsync();
        return entityById;
    }

    public async Task<GroupSubjectTime> Add(GroupSubjectTime entity)
    {
        _context.GroupSubjectTimes.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}