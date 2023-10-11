using UniversityPortal.Data;
using UniversityPortal.interfaces;
using UniversityPortal.Models;

namespace UniversityPortal.Repository;

public class SubjectRepository : ISubjectRepository
{
    private readonly DataContext _context;

    public SubjectRepository(DataContext context)
    {
        _context = context;
    }

    public ICollection<Subject> GetSubjects()
    {
        return _context.Subjects.ToList();
    }

    public Subject GetSubject(int id)
    {
        return _context.Subjects.SingleOrDefault(s => s.Id == id);
    }

    public bool SubjectExists(int id)
    {
        return _context.Subjects.Any(s => s.Id == id);
    }

    public bool CreateSubject(Subject subject)
    {
        _context.Subjects.Add(subject);
        var saved = _context.SaveChanges();

        return saved > 0;
    }
}