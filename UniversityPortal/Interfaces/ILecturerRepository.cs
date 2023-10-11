using UniversityPortal.Models;

namespace UniversityPortal.interfaces;

public interface ILecturerRepository
{
    ICollection<Lecturer> GetLecturers();
    Lecturer GetLecturer(int id);
    bool LecturerExists(int id);
    bool CreateLecturer(Lecturer lecturer);
}