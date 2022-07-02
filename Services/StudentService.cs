using StudentApi.Data;
using StudentApi.Entities;

namespace StudentApi.Services;

public class StudentService : IStudentService<Student>
{
    private readonly ILogger<StudentService> _logger;
    private readonly StudentDbContext _context;

    public StudentService(ILogger<StudentService> logger, StudentDbContext context)
    {
        _logger = logger;
        _context = context;
    }
    public Task<(bool IsSuccess, Exception e)> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Student>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Student> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<(bool IsSuccess, Exception e, Student entity)> InsertAsync(Student entity)
    {
        try
        {
            var res = await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return (true, null, entity);
        }
        catch (Exception e)
        {
            _logger.LogError($"New Student was not added {e.Message}");
            return (false, e, null);
        }
    }

    public Task<(bool IsSuccess, Exception e)> UpdateAsync(Student entity)
    {
        throw new NotImplementedException();
    }
}
