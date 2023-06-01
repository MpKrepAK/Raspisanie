using Microsoft.AspNetCore.Mvc;
using Raspisanie.Models.Database.Entitys;
using Raspisanie.Models.Database.Repositories.Interfaces;

namespace Raspisanie.Controllers;

[ApiController]
[Route("mainSchedules")]
public class MainScheduleCRUD : ControllerBase
{
    private readonly IRepository<MainSchedule> _repository;

    public MainScheduleCRUD(IRepository<MainSchedule> repository)
    {
        _repository = repository;
    }
    [HttpGet]
    public async Task<List<MainSchedule>> GetAll()
    {
        return await _repository.GetAll();
    }
    [HttpGet("{id}")]
    public async Task<MainSchedule> GetById(long id)
    {
        return await _repository.GetById(id);
    }
    [HttpPost]
    public async Task<MainSchedule> Add(MainSchedule entity)
    {
        return await _repository.Add(entity);
    }
    [HttpDelete("{id}")]
    public async Task<MainSchedule> Delete(long id)
    {
        return await _repository.Delete(id);
    }
    [HttpPut("{id}")]
    public async Task<MainSchedule> Update(long id, MainSchedule entity)
    {
        return await _repository.Update(id, entity);
    }
}