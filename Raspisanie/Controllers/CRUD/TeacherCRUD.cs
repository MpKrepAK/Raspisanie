using Microsoft.AspNetCore.Mvc;
using Raspisanie.Models.Database.Entitys;
using Raspisanie.Models.Database.Repositories.Interfaces;

namespace Raspisanie.Controllers;

[ApiController]
[Route("teachers")]
public class TeacherCRUD : ControllerBase
{
    private readonly IRepository<Teacher> _repository;

    public TeacherCRUD(IRepository<Teacher> repository)
    {
        _repository = repository;
    }
    [HttpGet]
    public async Task<List<Teacher>> GetAll()
    {
        return await _repository.GetAll();
    }
    [HttpGet("{id}")]
    public async Task<Teacher> GetById(long id)
    {
        return await _repository.GetById(id);
    }
    [HttpPost]
    public async Task<Teacher> Add(Teacher entity)
    {
        return await _repository.Add(entity);
    }
    [HttpDelete("{id}")]
    public async Task<Teacher> Delete(long id)
    {
        return await _repository.Delete(id);
    }
    [HttpPut("{id}")]
    public async Task<Teacher> Update(long id, Teacher entity)
    {
        return await _repository.Update(id, entity);
    }
}