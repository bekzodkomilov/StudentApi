using Microsoft.EntityFrameworkCore;
using StudentApi.Entities;

namespace StudentApi.Data;

public class StudentDbContext : DbContext
{
    public DbSet<Student> Students { get; set; }

    public StudentDbContext(DbContextOptions<StudentDbContext> options) 
        : base(options) { }
}