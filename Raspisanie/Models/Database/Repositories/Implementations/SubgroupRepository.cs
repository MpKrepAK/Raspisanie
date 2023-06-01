using Microsoft.EntityFrameworkCore;
using Raspisanie.Models.Database.Entitys;
using Raspisanie.Models.Database.Repositories.Interfaces;

namespace Raspisanie.Models.Database.Repositories.Implementations;

public class SubgroupRepository : IRepository<Subgroup>
{
    private readonly RaspisanieContext _context;
    public SubgroupRepository(RaspisanieContext context)
    {
        _context = context;
    }
    public async Task<List<Subgroup>> GetAll()
    {
        return await _context.Subgroups.ToListAsync();
    }

    public async Task<Subgroup> GetById(long id)
    {
        return await _context.Subgroups.FirstOrDefaultAsync(x=>x.Id==id);
    }

    public async Task<Subgroup> Update(long id, Subgroup entity)
    {
        var entityById = await _context.Subgroups.FirstOrDefaultAsync(x => x.Id == id);
        entityById.GroupId = entity.GroupId;
        entityById.Name = entity.Name;
        await _context.SaveChangesAsync();
        return entityById;
    }

    public async Task<Subgroup> Delete(long id)
    {
        var entityById = await _context.Subgroups.FirstOrDefaultAsync(x => x.Id == id);
        _context.Subgroups.Remove(entityById);
        await _context.SaveChangesAsync();
        return entityById;
    }

    public async Task<Subgroup> Add(Subgroup entity)
    {
        _context.Subgroups.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}