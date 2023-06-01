using Microsoft.AspNetCore.Mvc;
using Raspisanie.Models.Database.Entitys;
using Raspisanie.Models.Database.Repositories.Interfaces;

namespace Raspisanie.Controllers;

[ApiController]
[Route("subjects")]
public class SubjectCRUD : ControllerBase
{
    private readonly IRepository<Subject> _repository;

    public SubjectCRUD(IRepository<Subject> repository)
    {
        _repository = repository;
    }
    [HttpGet]
    public async Task<List<Subject>> GetAll()
    {
        return await _repository.GetAll();
    }
    [HttpGet("{id}")]
    public async Task<Subject> GetById(long id)
    {
        return await _repository.GetById(id);
    }
    [HttpPost]
    public async Task<Subject> Add(Subject entity)
    {
        return await _repository.Add(entity);
    }
    [HttpDelete("{id}")]
    public async Task<Subject> Delete(long id)
    {
        return await _repository.Delete(id);
    }
    [HttpPut("{id}")]
    public async Task<Subject> Update(long id, Subject entity)
    {
        return await _repository.Update(id, entity);
    }
}