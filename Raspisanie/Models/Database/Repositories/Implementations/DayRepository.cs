using Microsoft.EntityFrameworkCore;
using Raspisanie.Models.Database.Entitys;
using Raspisanie.Models.Database.Repositories.Interfaces;

namespace Raspisanie.Models.Database.Repositories.Implementations;

public class DayRepository : IRepository<Day>
{
    private readonly RaspisanieContext _context;
    public DayRepository(RaspisanieContext context)
    {
        _context = context;
    }
    public async Task<List<Day>> GetAll()
    {
        return await _context.Days.ToListAsync();
    }

    public async Task<Day> GetById(long id)
    {
        return await _context.Days.FirstOrDefaultAsync(x=>x.Id==id);
    }

    public async Task<Day> Update(long id, Day entity)
    {
        var entityById = await _context.Days.FirstOrDefaultAsync(x => x.Id == id);
        entityById.Name = entity.Name;
        await _context.SaveChangesAsync();
        return entityById;
    }

    public async Task<Day> Delete(long id)
    {
        var entityById = await _context.Days.FirstOrDefaultAsync(x => x.Id == id);
        _context.Days.Remove(entityById);
        await _context.SaveChangesAsync();
        return entityById;
    }

    public async Task<Day> Add(Day entity)
    {
        _context.Days.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}