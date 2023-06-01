using Microsoft.AspNetCore.Mvc;
using Raspisanie.Models.Database.Entitys;
using Raspisanie.Models.Database.Repositories.Interfaces;

namespace Raspisanie.Controllers;

[ApiController]
[Route("teacherSubject")]
public class TeacherSubjectCRUD : ControllerBase
{
    private readonly IRepository<TeacherSubject> _repository;

    public TeacherSubjectCRUD(IRepository<TeacherSubject> repository)
    {
        _repository = repository;
    }
    [HttpGet]
    public async Task<List<TeacherSubject>> GetAll()
    {
        return await _repository.GetAll();
    }
    [HttpGet("{id}")]
    public async Task<TeacherSubject> GetById(long id)
    {
        return await _repository.GetById(id);
    }
    [HttpPost]
    public async Task<TeacherSubject> Add(TeacherSubject entity)
    {
        return await _repository.Add(entity);
    }
    [HttpDelete("{id}")]
    public async Task<TeacherSubject> Delete(long id)
    {
        return await _repository.Delete(id);
    }
    [HttpPut("{id}")]
    public async Task<TeacherSubject> Update(long id, TeacherSubject entity)
    {
        return await _repository.Update(id, entity);
    }
}