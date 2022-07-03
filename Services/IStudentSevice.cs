namespace StudentApi.Services;


public interface IStudentService <TEntity> where TEntity : class
{
    Task<(bool IsSuccess, Exception e, TEntity entity)> InsertAsync(TEntity entity);
    Task<bool> UpdateAsync(Guid id);
    Task<TEntity> GetByIdAsync(Guid id);
    Task<List<TEntity>> GetAllAsync();
    Task<(bool IsSuccess, Exception e)> DeleteAsync(Guid id);
}