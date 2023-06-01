using Microsoft.AspNetCore.Mvc;
using Raspisanie.Models.Database;
using Raspisanie.Models.Database.Entitys;
using Raspisanie.Models.Database.Repositories.Interfaces;

namespace Raspisanie.Controllers;

[ApiController]
[Route("days")]
public class DayCRUD : ControllerBase
{
    private readonly IRepository<Day> _repository;

    public DayCRUD(IRepository<Day> repository)
    {
        _repository = repository;
    }
    [HttpGet]
    public async Task<List<Day>> GetAll()
    {
        return await _repository.GetAll();
    }
    [HttpGet("{id}")]
    public async Task<Day> GetById(long id)
    {
        return await _repository.GetById(id);
    }
    [HttpPost]
    public async Task<Day> Add(Day entity)
    {
        return await _repository.Add(entity);
    }
    [HttpDelete("{id}")]
    public async Task<Day> Delete(long id)
    {
        return await _repository.Delete(id);
    }
    [HttpPut("{id}")]
    public async Task<Day> Update(long id, Day entity)
    {
        return await _repository.Update(id, entity);
    }
}