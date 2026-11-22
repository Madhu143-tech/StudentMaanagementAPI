using Microsoft.AspNetCore.Mvc;
using StudentManagementAPI.Models;

namespace StudentManagementAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class StudentsController : ControllerBase
{
    private static readonly List<Student> Students =
    [
        new Student
        {
            Id = 1,
            Name = "Madhusudhan J",
            Email = "madhusudan.j.133659@marwadiiuniversity.ac.in",
            Department = "Computer Science and Engineering",
            Semester = 5,
            Cgpa = 9.45,
            EnrollmentDate = new DateTime(2024, 8, 1)
        },
        new Student
        {
            Id = 2,
            Name = "Rohan Sharma",
            Email = "rohan.sharma@marwadiuniversity.ac.in",
            Department = "Information Technology",
            Semester = 5,
            Cgpa = 8.80,
            EnrollmentDate = new DateTime(2024, 8, 1)
        },
        new Student
        {
            Id = 3,
            Name = "Priya Varma",
            Email = "priya.varma@marwadiuniversity.ac.in",
            Department = "Computer Science and Engineering",
            Semester = 5,
            Cgpa = 9.15,
            EnrollmentDate = new DateTime(2024, 8, 1)
        }
    ];

    // GET: api/Students
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Student>), StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<Student>> GetStudents()
    {
        return Ok(Students);
    }

    // GET: api/Students/5
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Student), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Student> GetStudent(int id)
    {
        var student = Students.FirstOrDefault(s => s.Id == id);
        if (student == null)
        {
            return NotFound(new { message = $"Student with ID {id} not found." });
        }
        return Ok(student);
    }

    // POST: api/Students
    [HttpPost]
    [ProducesResponseType(typeof(Student), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<Student> CreateStudent([FromBody] Student student)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        student.Id = Students.Count == 0 ? 1 : Students.Max(s => s.Id) + 1;
        student.EnrollmentDate = DateTime.Now;
        Students.Add(student);

        return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
    }

    // PUT: api/Students/5
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult UpdateStudent(int id, [FromBody] Student updatedStudent)
    {
        if (id != updatedStudent.Id) return BadRequest(new { message = "ID mismatch." });

        var existing = Students.FirstOrDefault(s => s.Id == id);
        if (existing == null) return NotFound(new { message = $"Student #{id} not found." });

        existing.Name = updatedStudent.Name;
        existing.Email = updatedStudent.Email;
        existing.Department = updatedStudent.Department;
        existing.Semester = updatedStudent.Semester;
        existing.Cgpa = updatedStudent.Cgpa;

        return NoContent();
    }

    // DELETE: api/Students/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult DeleteStudent(int id)
    {
        var student = Students.FirstOrDefault(s => s.Id == id);
        if (student == null) return NotFound(new { message = $"Student #{id} not found." });

        Students.Remove(student);
        return NoContent();
    }
}
