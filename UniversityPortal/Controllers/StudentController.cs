using Microsoft.AspNetCore.Mvc;
using UniversityPortal.Dto;
using UniversityPortal.interfaces;
using UniversityPortal.Models;

namespace UniversityPortal.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class StudentController : ControllerBase
{
    private readonly IStudentRepository _studentRepository;
    private readonly ISubjectRepository _subjectRepository;

    public StudentController(IStudentRepository studentRepository, ISubjectRepository subjectRepository)
    {
        _studentRepository = studentRepository;
        _subjectRepository = subjectRepository;
    }

    [HttpGet("/Students")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Student>))]
    public IActionResult GetStudents()
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(_studentRepository.GetStudents());
    }
    
    [HttpGet("/Students/{id}/PaymentPrice")]
    [ProducesResponseType(200, Type = typeof(float))]
    public IActionResult GetPaymentPrice(int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(_studentRepository.CalculatePaymentPrice(id));
    }

    [HttpGet("/Students/{id}")]
    [ProducesResponseType(200, Type = typeof(Student))]
    public IActionResult GetStudent(int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(_studentRepository.GetStudent(id));
    }

    [HttpGet("/Students/{id}/Exists")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Student>))]
    public IActionResult IsStudentExists(int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(_studentRepository.StudentExists(id));
    }


    [HttpPost("/CreateStudent")]
    [ProducesResponseType(200)]
    public IActionResult CreateStudent(StudentDto student)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        foreach (var subjId in student.SubjectIds)
        {
            if (!_subjectRepository.SubjectExists(subjId))
            {
                return BadRequest($"Subject with Id {subjId} doesn't exists!");
            }
        }

        var exceptedStudent = new Student
        {
            Id = student.Id,
            FirstName = student.FirstName,
            LastName = student.LastName,
            Email = student.Email,
            SubjectIds = string.Join(", ", student.SubjectIds)
        };

        var isStudentCreated = _studentRepository.CreateStudent(exceptedStudent);
        if (!isStudentCreated)
        {
            return BadRequest("Student have not created!");
        }

        return Ok();
    }
}