using Microsoft.AspNetCore.Mvc;
using Raspisanie.Models.Database.Entitys;
using Raspisanie.Models.Database.Repositories.Interfaces;

namespace Raspisanie.Controllers;

[ApiController]
[Route("groups")]
public class GroupCRUD : ControllerBase
{
    private readonly IRepository<Group> _repository;

    public GroupCRUD(IRepository<Group> repository)
    {
        _repository = repository;
    }
    [HttpGet]
    public async Task<List<Group>> GetAll()
    {
        return await _repository.GetAll();
    }
    [HttpGet("{id}")]
    public async Task<Group> GetById(long id)
    {
        return await _repository.GetById(id);
    }
    [HttpPost]
    public async Task<Group> Add(Group entity)
    {
        return await _repository.Add(entity);
    }
    [HttpDelete("{id}")]
    public async Task<Group> Delete(long id)
    {
        return await _repository.Delete(id);
    }
    [HttpPut("{id}")]
    public async Task<Group> Update(long id, Group entity)
    {
        return await _repository.Update(id, entity);
    }
}