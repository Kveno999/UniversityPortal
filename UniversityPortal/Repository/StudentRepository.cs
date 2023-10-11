using UniversityPortal.Data;
using UniversityPortal.interfaces;
using UniversityPortal.Models;

namespace UniversityPortal.Repository;

public class StudentRepository : IStudentRepository
{
    private readonly DataContext _context;
    private readonly ISubjectRepository _subjectRepository;

    public StudentRepository(DataContext context, ISubjectRepository subjectRepository)
    {
        _context = context;
        _subjectRepository = subjectRepository;
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

    public decimal? CalculatePaymentPrice(int id)
    {
        var student = GetStudent(id);
        var subjectIds = student.SubjectIds?.Split(", ");

        return (from sId in subjectIds select Convert.ToInt32(sId) 
            into subjectId select _subjectRepository.GetSubject(subjectId) 
            into subject select subject.CreditPrice).Sum();
    }

    public bool CreateStudent(Student student)
    {
        _context.Students.Add(student);

        var saved = _context.SaveChanges();

        return saved > 0;
    }
}