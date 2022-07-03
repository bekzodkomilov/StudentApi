using StudentApi.Models;

namespace StudentApi.Services;


public interface IStudentService <TEntity> where TEntity : class
{
    Task<(bool IsSuccess, Exception e, TEntity entity)> InsertAsync(TEntity entity);
    Task<(bool IsSuccess, Exception e)> UpdateAsync(TEntity entity);
    Task<TEntity> GetByIdAsync(Guid id);
    Task<List<TEntity>> GetAllAsync();
    Task<(bool IsSuccess, Exception e)> DeleteAsync(Guid id);
}