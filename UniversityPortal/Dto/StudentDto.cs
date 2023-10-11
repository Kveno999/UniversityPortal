namespace UniversityPortal.Dto;

public class StudentDto
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public IEnumerable<int>? SubjectIds { get; set; }
}