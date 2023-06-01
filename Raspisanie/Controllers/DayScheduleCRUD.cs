using Microsoft.AspNetCore.Mvc;
using Raspisanie.Models.Database.Entitys;
using Raspisanie.Models.Database.Repositories.Interfaces;

namespace Raspisanie.Controllers;

[ApiController]
[Route("daySchedules")]
public class DayScheduleCRUD : ControllerBase
{
    private readonly IRepository<DaySchedule> _repository;

    public DayScheduleCRUD(IRepository<DaySchedule> repository)
    {
        _repository = repository;
    }
    [HttpGet]
    public async Task<List<DaySchedule>> GetAll()
    {
        return await _repository.GetAll();
    }
    [HttpGet("{id}")]
    public async Task<DaySchedule> GetById(long id)
    {
        return await _repository.GetById(id);
    }
    [HttpPost]
    public async Task<DaySchedule> Add(DaySchedule entity)
    {
        return await _repository.Add(entity);
    }
    [HttpDelete("{id}")]
    public async Task<DaySchedule> Delete(long id)
    {
        return await _repository.Delete(id);
    }
    [HttpPatch("{id}")]
    public async Task<DaySchedule> Update(long id, DaySchedule entity)
    {
        return await _repository.Update(id, entity);
    }
}