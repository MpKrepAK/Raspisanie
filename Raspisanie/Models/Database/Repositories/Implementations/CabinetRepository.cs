using Microsoft.EntityFrameworkCore;
using Raspisanie.Models.Database.Entitys;
using Raspisanie.Models.Database.Repositories.Interfaces;

namespace Raspisanie.Models.Database.Repositories.Implementations;

public class CabinetRepository : IRepository<Cabinet>
{
    private readonly RaspisanieContext _context;
    public CabinetRepository(RaspisanieContext context)
    {
        _context = context;
    }
    public async Task<List<Cabinet>> GetAll()
    {
        return await _context.Cabinets.Include(x=>x.DaySchedules).Include(x=>x.MainSchedules).ToListAsync();
        //return await _context.Cabinets.ToListAsync();
    }

    public async Task<Cabinet> GetById(long id)
    {
        return await _context.Cabinets
            .Include(x=>x.DaySchedules)
            .Include(x=>x.MainSchedules)
            .FirstOrDefaultAsync(x=>x.Id==id);
        //return await _context.Cabinets.FirstOrDefaultAsync(x=>x.Id==id);
    }

    public async Task<Cabinet> Update(long id, Cabinet entity)
    {
        var entityById = await _context.Cabinets.FirstOrDefaultAsync(x => x.Id == id);
        entityById.Number = entity.Number;
        await _context.SaveChangesAsync();
        return entityById;
    }

    public async Task<Cabinet> Delete(long id)
    {
        var entityById = await _context.Cabinets.FirstOrDefaultAsync(x => x.Id == id);
        _context.Cabinets.Remove(entityById);
        await _context.SaveChangesAsync();
        return entityById;
    }

    public async Task<Cabinet> Add(Cabinet entity)
    {
        _context.Cabinets.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}