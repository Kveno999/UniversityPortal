using Microsoft.EntityFrameworkCore;
using UniversityPortal.Models;

namespace UniversityPortal.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }
    
    public DbSet<Student> Students { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Lecturer> Lecturers { get; set; }
}