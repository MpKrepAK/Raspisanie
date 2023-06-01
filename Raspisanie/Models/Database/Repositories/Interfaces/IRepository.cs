namespace Raspisanie.Models.Database.Repositories.Interfaces;

public interface IRepository<T>
{
    public Task<List<T>> GetAll();
    public Task<T> GetById(long id);
    public Task<T> Update(long id, T entity);
    public Task<T> Delete(long id);
    public Task<T> Add(T entity);
    //public Task<T> GetBuId(long id);
}