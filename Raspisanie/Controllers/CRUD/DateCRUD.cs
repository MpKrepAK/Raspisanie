using Microsoft.AspNetCore.Mvc;
using Raspisanie.Models.Database.Entitys;
using Raspisanie.Models.Database.Repositories.Interfaces;

namespace Raspisanie.Controllers;

[ApiController]
[Route("date")]
public class DateCRUD : ControllerBase
{
    private readonly IRepository<Date> _repository;

    public DateCRUD(IRepository<Date> repository)
    {
        _repository = repository;
    }
    [HttpGet]
    public async Task<List<Date>> GetAll()
    {
        return await _repository.GetAll();
    }
    [HttpGet("{id}")]
    public async Task<Date> GetById(long id)
    {
        return await _repository.GetById(id);
    }
    [HttpPost]
    public async Task<Date> Add(Date entity)
    {
        return await _repository.Add(entity);
    }
    [HttpDelete("{id}")]
    public async Task<Date> Delete(long id)
    {
        return await _repository.Delete(id);
    }
    [HttpPut("{id}")]
    public async Task<Date> Update(long id, Date entity)
    {
        return await _repository.Update(id, entity);
    }
}