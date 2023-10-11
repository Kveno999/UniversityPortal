using Microsoft.AspNetCore.Mvc;
using UniversityPortal.interfaces;
using UniversityPortal.Models;

namespace UniversityPortal.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class LecturerController : Controller
{
    
    private readonly ILecturerRepository _lecturerRepository;
    private readonly ISubjectRepository _subjectRepository;

    public LecturerController(ILecturerRepository lecturerRepository, ISubjectRepository subjectRepository)
    {
        _lecturerRepository = lecturerRepository;
        _subjectRepository = subjectRepository;
    }

    [HttpGet("/Lecturers")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Lecturer>))]
    public IActionResult GetLecturers()
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok(_lecturerRepository.GetLecturers());
    }
    
    [HttpGet("/Lecturers/{id}")]
    [ProducesResponseType(200, Type = typeof(Lecturer))]
    public IActionResult GetLecturer(int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok(_lecturerRepository.GetLecturer(id));
    }
    
    [HttpGet("/Lecturer/{id}/Exists")]
    [ProducesResponseType(200, Type = typeof(bool))]
    public IActionResult IsLecturerExists(int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok(_lecturerRepository.LecturerExists(id));
    }
    
    
    [HttpPost("/CreateLecturer")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public IActionResult CreateLecturer(Lecturer lecturer)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (_lecturerRepository.LecturerExists(lecturer.Id))
        {
            return BadRequest("Subject Already Exists!");
        }

        if (!_subjectRepository.SubjectExists(lecturer.SubjectId))
        {
            return BadRequest($"Subject with id {lecturer.SubjectId}, doesn't exists");
        }

        var isLecturerCreated = _lecturerRepository.CreateLecturer(lecturer);
        if (!isLecturerCreated)
        {
            return BadRequest("Student have not created!");
        }
        return Ok();
    }
    
}