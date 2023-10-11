using UniversityPortal.Models;

namespace UniversityPortal.interfaces;

public interface ISubjectRepository
{
    ICollection<Subject> GetSubjects();
    Subject GetSubject(int id);
    bool SubjectExists(int id);
    bool CreateSubject(Subject subject);
}