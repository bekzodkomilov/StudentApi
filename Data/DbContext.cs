using Microsoft.EntityFrameworkCore;
using StudentApi.Entities;

namespace StudentApi.Data;

public class StudnetDbContext : DbContext
{
    public DbSet<Student> Students { get; set; }

    public StudnetDbContext(DbContextOptions<StudnetDbContext> options) 
        : base(options) { }
}