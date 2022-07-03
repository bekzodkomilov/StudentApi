using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
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
    public async Task<(bool IsSuccess, Exception e)> DeleteAsync(Guid id)
    {
        try
        {
            var student = await GetByIdAsync(id);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return (true, null);
        }
        catch (Exception e)
        {
            return (false, e);
        }
    }

    public  Task<List<Student>> GetAllAsync()
      => Task.FromResult(_context.Students.ToList());

    public async Task<Student> GetByIdAsync(Guid id)
    {
        return await _context.Students.FirstOrDefaultAsync(p => p.Id == id);
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

     public async Task<(bool IsSuccess, Exception e)> UpdateAsync(Student entity)
    {
        try
        {
            _context.Students.Update(entity);
            await _context.SaveChangesAsync();
            return (true, null);
        }
        catch (Exception e)
        {
            _logger.LogError($"Student was not updated.\n{e.Message}");
            return (false, e);
        }
    }
}
