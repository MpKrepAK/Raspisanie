using Microsoft.AspNetCore.Mvc;
using Raspisanie.Models.Database.Entitys;
using Raspisanie.Models.Database.Repositories.Interfaces;

namespace Raspisanie.Controllers;

[ApiController]
[Route("subgroups")]
public class SubgroupCRUD : ControllerBase
{
    private readonly IRepository<Subgroup> _repository;

    public SubgroupCRUD(IRepository<Subgroup> repository)
    {
        _repository = repository;
    }
    [HttpGet]
    public async Task<List<Subgroup>> GetAll()
    {
        return await _repository.GetAll();
    }
    [HttpGet("{id}")]
    public async Task<Subgroup> GetById(long id)
    {
        return await _repository.GetById(id);
    }
    [HttpPost]
    public async Task<Subgroup> Add(Subgroup entity)
    {
        return await _repository.Add(entity);
    }
    [HttpDelete("{id}")]
    public async Task<Subgroup> Delete(long id)
    {
        return await _repository.Delete(id);
    }
    [HttpPut("{id}")]
    public async Task<Subgroup> Update(long id, Subgroup entity)
    {
        return await _repository.Update(id, entity);
    }
}