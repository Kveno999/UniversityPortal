namespace UniversityPortal.Models;

public class Lecturer
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public IEnumerable<Subject> Subjects { get; set; }
}