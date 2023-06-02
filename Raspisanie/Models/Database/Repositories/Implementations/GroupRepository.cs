using Microsoft.EntityFrameworkCore;
using Raspisanie.Models.Database.Entitys;
using Raspisanie.Models.Database.Repositories.Interfaces;

namespace Raspisanie.Models.Database.Repositories.Implementations;

public class GroupRepository : IRepository<Group>
{
    private readonly RaspisanieContext _context;
    public GroupRepository(RaspisanieContext context)
    {
        _context = context;
    }
    public async Task<List<Group>> GetAll()
    {
        return await _context.Groups
            .Include(x=>x.Subgroups)
            .ToListAsync();
        //return await _context.Groups.ToListAsync();
    }

    public async Task<Group> GetById(long id)
    {
        return await _context.Groups
            .Include(x=>x.Subgroups)
            .FirstOrDefaultAsync(x=>x.Id==id);
        //return await _context.Groups.FirstOrDefaultAsync(x=>x.Id==id);
    }

    public async Task<Group> Update(long id, Group entity)
    {
        var entityById = await _context.Groups.FirstOrDefaultAsync(x => x.Id == id);
        entityById.Name = entity.Name;
        await _context.SaveChangesAsync();
        return entityById;
    }

    public async Task<Group> Delete(long id)
    {
        var entityById = await _context.Groups.FirstOrDefaultAsync(x => x.Id == id);
        _context.Groups.Remove(entityById);
        await _context.SaveChangesAsync();
        return entityById;
    }

    public async Task<Group> Add(Group entity)
    {
        _context.Groups.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}