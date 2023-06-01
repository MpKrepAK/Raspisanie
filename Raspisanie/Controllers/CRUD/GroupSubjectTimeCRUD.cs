using Microsoft.AspNetCore.Mvc;
using Raspisanie.Models.Database.Entitys;
using Raspisanie.Models.Database.Repositories.Interfaces;

namespace Raspisanie.Controllers;

[ApiController]
[Route("groupSubjectTimes")]
public class GroupSubjectTimeCRUD : ControllerBase
{
    private readonly IRepository<GroupSubjectTime> _repository;

    public GroupSubjectTimeCRUD(IRepository<GroupSubjectTime> repository)
    {
        _repository = repository;
    }
    [HttpGet]
    public async Task<List<GroupSubjectTime>> GetAll()
    {
        return await _repository.GetAll();
    }
    [HttpGet("{id}")]
    public async Task<GroupSubjectTime> GetById(long id)
    {
        return await _repository.GetById(id);
    }
    [HttpPost]
    public async Task<GroupSubjectTime> Add(GroupSubjectTime entity)
    {
        return await _repository.Add(entity);
    }
    [HttpDelete("{id}")]
    public async Task<GroupSubjectTime> Delete(long id)
    {
        return await _repository.Delete(id);
    }
    [HttpPut("{id}")]
    public async Task<GroupSubjectTime> Update(long id, GroupSubjectTime entity)
    {
        return await _repository.Update(id, entity);
    }
}