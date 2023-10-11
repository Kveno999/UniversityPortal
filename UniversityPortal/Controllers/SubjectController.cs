using Microsoft.AspNetCore.Mvc;
using UniversityPortal.interfaces;
using UniversityPortal.Models;

namespace UniversityPortal.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class SubjectController : Controller
{
    
    private readonly ISubjectRepository _subjectRepository;

    public SubjectController(ISubjectRepository subjectRepository)
    {
        _subjectRepository = subjectRepository;
    }

    [HttpGet("/Subjects")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Subject>))]
    public IActionResult GetSubjects()
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok(_subjectRepository.GetSubjects());
    }
    
    [HttpGet("/Subjects/{id}")]
    [ProducesResponseType(200, Type = typeof(Subject))]
    public IActionResult GetSubject(int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok(_subjectRepository.GetSubject(id));
    }
    
    [HttpGet("/Subject/{id}/Exists")]
    [ProducesResponseType(200, Type = typeof(bool))]
    public IActionResult IsSubjectExists(int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok(_subjectRepository.SubjectExists(id));
    }
    
    
    [HttpPost("/CreateSubject")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public IActionResult CreateSubject(Subject subject)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (_subjectRepository.SubjectExists(subject.Id))
        {
            return BadRequest("Subject Already Exists!");
        }

        var isStudentCreated = _subjectRepository.CreateSubject(subject);
        if (!isStudentCreated)
        {
            return BadRequest("Student have not created!");
        }
        return Ok();
    }
    
}