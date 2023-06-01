using Microsoft.AspNetCore.Mvc;
using Raspisanie.Models.Database.Entitys;
using Raspisanie.Models.Database.Repositories.Interfaces;

namespace Raspisanie.Controllers;

[ApiController]
[Route("cabinets")]
public class CabinetCRUD
{
    private readonly IRepository<Cabinet> _repository;

    public CabinetCRUD(IRepository<Cabinet> repository)
    {
        _repository = repository;
    }
    [HttpGet]
    public async Task<List<Cabinet>> GetAll()
    {
        return await _repository.GetAll();
    }
    [HttpGet("{id}")]
    public async Task<Cabinet> GetById(long id)
    {
        return await _repository.GetById(id);
    }
    [HttpPost]
    public async Task<Cabinet> Add(Cabinet entity)
    {
        return await _repository.Add(entity);
    }
    [HttpDelete("{id}")]
    public async Task<Cabinet> Delete(long id)
    {
        return await _repository.Delete(id);
    }
    [HttpPut("{id}")]
    public async Task<Cabinet> Update(long id, Cabinet entity)
    {
        return await _repository.Update(id, entity);
    }
}