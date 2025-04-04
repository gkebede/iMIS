using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<Student> _logger;
        private readonly DataContext _context;
 

        public StudentController(ILogger<Student> logger, DataContext context)
        {
            _context = context;
            _logger = logger;
        }

        
        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetStudentsAsync()
        {
              
            //  return Ok(await _context.Set<Student>().ToListAsync()); 
            return Ok(await _context.Students.ToListAsync());   
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudentByIdAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }
 
        [HttpPost]
        public async Task<ActionResult<List<Student>>> CreateStudentsAsync(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return Ok(await _context.Students.ToListAsync());
        }
        [HttpPut("{id}")]   
        public async Task<ActionResult<List<Student>>> UpdateStudentAsync(int id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest("Student ID mismatch.");
            }

            var existingStudent = await _context.Students.FindAsync(id);
            if (existingStudent == null)
            {
                return NotFound();
            }

            existingStudent.FirstName = student.FirstName;
            existingStudent.BirthDay = student.BirthDay;
            existingStudent.PhoneNumber = student.PhoneNumber;
            existingStudent.Email = student.Email;
            existingStudent.Pronoun = student.Pronoun;
            existingStudent.UniversityAttending = student.UniversityAttending;
            await _context.SaveChangesAsync();
            return Ok(await _context.Students.ToListAsync());
        }

        [HttpDelete("{id}")]    
        public async Task<ActionResult<List<Student>>> DeleteStudentAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return Ok(await _context.Students.ToListAsync());
        }

        // http://localhost:5219/Student/search/by-name/John
        [HttpGet("search/by-name/{name}")]
        public async Task<ActionResult<List<Student>>> SearchStudentsByNameAsync(string name)
        {
            var students = await _context.Students
                .Where(s => s.FirstName.Contains(name) || s.LastName.Contains(name))
                .ToListAsync();

            if (students.Count == 0)
            {
                return NotFound("No students found with the given name.");
            }

            return Ok(students);
        }

        //http://localhost:5219/Student/search/by-email/johndoe@gmail.com
        [HttpGet("search/by-email/{email}")] 
        public async Task<ActionResult<List<Student>>> SearchStudentsByEmailAsync(string email)
        {
            var students = await _context.Students
                .Where(s => s.Email.Contains(email))
                .ToListAsync();

            if (students.Count == 0)
            {
                return NotFound("No students found with the given email.");
            }

            return Ok(students); 
        }   
      

     
    }
}