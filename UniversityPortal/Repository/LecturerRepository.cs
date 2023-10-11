using UniversityPortal.Data;
using UniversityPortal.interfaces;
using UniversityPortal.Models;

namespace UniversityPortal.Repository;

public class LecturerRepository : ILecturerRepository
{
    private readonly DataContext _context;

    public LecturerRepository(DataContext context)
    {
        _context = context;
    }

    public ICollection<Lecturer> GetLecturers()
    {
        return _context.Lecturers.OrderBy(s => s.Id).ToList();
    }

    public Lecturer GetLecturer(int id)
    {
        return _context.Lecturers.SingleOrDefault(s => s.Id == id);
    }

    public bool LecturerExists(int id)
    {
        return _context.Lecturers.Any(s => s.Id == id);
    }

    public bool CreateLecturer(Lecturer lecturer)
    {
        _context.Lecturers.Add(lecturer);
        var saved = _context.SaveChanges();

        return saved > 0;
    }
}