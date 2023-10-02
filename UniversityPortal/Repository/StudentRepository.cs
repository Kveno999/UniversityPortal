using UniversityPortal.Data;
using UniversityPortal.interfaces;
using UniversityPortal.Models;

namespace UniversityPortal.Repository;

public class StudentRepository : IStudentRepository
{
    private readonly DataContext _context;

    public StudentRepository(DataContext context)
    {
        _context = context;
    }

    public ICollection<Student> GetStudents()
    {
        return _context.Students.OrderBy(s => s.Id).ToList();
    }

    public Student GetStudent(int id)
    {
        return _context.Students.Where(p => p.Id == id).FirstOrDefault();
    }

    public bool StudentExists(int id)
    {
        return _context.Students.Any(s => s.Id == id);
    }

    public bool CreateStudent(Student student)
    {
        _context.Students.Add(student);

        var saved = _context.SaveChanges();

        return saved > 0;
    }
}