using Microsoft.EntityFrameworkCore;
using Raspisanie.Models.Database.Entitys;
using Raspisanie.Models.Database.Repositories.Interfaces;

namespace Raspisanie.Models.Database.Repositories.Implementations;

public class DateRepository : IRepository<Date>
{
    private readonly RaspisanieContext _context;
    public DateRepository(RaspisanieContext context)
    {
        _context = context;
    }
    public async Task<List<Date>> GetAll()
    {
        return await _context.Dates
            .Include(x=>x.DaySchedules)
            .ToListAsync();
        //return await _context.Dates.ToListAsync();
    }

    public async Task<Date> GetById(long id)
    {
        return await _context.Dates
            .Include(x=>x.DaySchedules)
            .FirstOrDefaultAsync(x=>x.Id==id);
        //return await _context.Dates.FirstOrDefaultAsync(x=>x.Id==id);
    }

    public async Task<Date> Update(long id, Date entity)
    {
        var entityById = await _context.Dates.FirstOrDefaultAsync(x => x.Id == id);
        entityById.DateValue = entity.DateValue;
        await _context.SaveChangesAsync();
        return entityById;
    }

    public async Task<Date> Delete(long id)
    {
        var entityById = await _context.Dates.FirstOrDefaultAsync(x => x.Id == id);
        _context.Dates.Remove(entityById);
        await _context.SaveChangesAsync();
        return entityById;
    }

    public async Task<Date> Add(Date entity)
    {
        _context.Dates.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}