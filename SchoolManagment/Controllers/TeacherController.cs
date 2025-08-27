using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using SchoolManagment.Models;
using SchoolManagment.Services;

namespace SchoolManagment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _service;
        public TeacherController(ITeacherService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTeachers()
        {
            var teachers = await _service.GetTeachers();
            if (teachers.Count == 0)
            {
                return NotFound();
            }
            return Ok(teachers);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>GetTeacherById(int id)
        {
            var teacher = await _service.GetTeacher(id);
            if (teacher == null)
            {
                return NotFound();
            }
            return Ok(teacher);
        }
        [HttpPost]

        public async Task<IActionResult>AddTeacher(Teachers teacher)
        {
            var newTeacher = await _service.AddTeacher(teacher);
            if(newTeacher != null)
            {
                return Ok(newTeacher);
            }
            return BadRequest();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult>UpdateTeacher(Teachers teacher)
        {
            var updatedTeacher = await _service.UpdateTeacher(teacher);
            if(updatedTeacher == null)
            {
                return NotFound();
            }
            return Ok(updatedTeacher);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteTeacher(int id)
        {
            var isDeleted=await _service.DeleteTeacher(id);
            if (!isDeleted)
            {
                return NotFound();
            }
            return Ok(true);
        }
    }
}
