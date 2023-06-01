using Microsoft.AspNetCore.Mvc;
using Raspisanie.Models.Database.Entitys;
using Raspisanie.Models.Database.Repositories.Interfaces;

namespace Raspisanie.Controllers;

[ApiController]
[Route("replacementTeachers")]
public class ReplacementTeacherCRUD : ControllerBase
{
    private readonly IRepository<ReplacementTeacher> _repository;

    public ReplacementTeacherCRUD(IRepository<ReplacementTeacher> repository)
    {
        _repository = repository;
    }
    [HttpGet]
    public async Task<List<ReplacementTeacher>> GetAll()
    {
        return await _repository.GetAll();
    }
    [HttpGet("{id}")]
    public async Task<ReplacementTeacher> GetById(long id)
    {
        return await _repository.GetById(id);
    }
    [HttpPost]
    public async Task<ReplacementTeacher> Add(ReplacementTeacher entity)
    {
        return await _repository.Add(entity);
    }
    [HttpDelete("{id}")]
    public async Task<ReplacementTeacher> Delete(long id)
    {
        return await _repository.Delete(id);
    }
    [HttpPut("{id}")]
    public async Task<ReplacementTeacher> Update(long id, ReplacementTeacher entity)
    {
        return await _repository.Update(id, entity);
    }
}