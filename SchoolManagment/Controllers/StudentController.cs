using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagment.Models;
using SchoolManagment.Services;

namespace SchoolManagment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _studentService.GetAllStudents();
            if (students.Count == 0)
            {
                return NotFound();
            }
            return Ok(students);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> StudentById(int id)
        {
            var student = await _studentService.GetStudent(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }
        [HttpPost]
        public async Task<IActionResult> CreateStudent(Students students)
        {
            var created_Student = await _studentService.AddStudents(students);
            if (created_Student != null)
            {
                return Ok(created_Student);
            }
            return BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateStudent(Students students)
        {
            var updated_Student = await _studentService.UpdateStudent(students);
            if (updated_Student == null)
            {
                return NotFound();

            }
            return Ok(updated_Student);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteStudent(int id)
        {
            var isDeleted=await _studentService.DeleteStudent(id);
            if (!isDeleted)
            {
                return NotFound();
            }
            return Ok(true);
        }

    }

}
