using Microsoft.EntityFrameworkCore;
using UniversityPortal.Models;

namespace UniversityPortal.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }
    
    public DbSet<Student> Students { get; set; }
}