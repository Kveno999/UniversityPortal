using UniversityPortal.Models;

namespace UniversityPortal.interfaces;

public interface IStudentRepository
{
    ICollection<Student> GetStudents();
    Student GetStudent(int id);
    bool StudentExists(int id);
    bool CreateStudent(Student student);
    decimal? CalculatePaymentPrice(int id);
}