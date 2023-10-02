using Microsoft.AspNetCore.Mvc;
using UniversityPortal.interfaces;
using UniversityPortal.Models;

namespace UniversityPortal.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class StudentController : ControllerBase
{
    private readonly IStudentRepository _studentRepository;

    public StudentController(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
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
    public IActionResult CreateStudent(Student student)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var isStudentCreated = _studentRepository.CreateStudent(student);
        if (!isStudentCreated)
        {
            return BadRequest("Student have not created!");
        }
        return Ok();
    }

}