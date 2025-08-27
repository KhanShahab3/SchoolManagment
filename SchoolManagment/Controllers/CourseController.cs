using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagment.Models;
using SchoolManagment.Services;

namespace SchoolManagment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCourses()
        {
                       var courses = await _courseService.GetAllCourses();
            if (courses.Count == 0)
            {
                return NotFound();
            }
            return Ok(courses);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            var course = await _courseService.GetCourse(id);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }
        [HttpPost]
        public async Task<IActionResult>AddCourse(Courses course)
        {
                       var newCourse = await _courseService.AddCourse(course);
            if (newCourse != null)
            {
                return Ok(newCourse);
            }
            return BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCourse(Courses course)
        {
                       var updatedCourse = await _courseService.UpdateCourse(course);
            if (updatedCourse == null)
            {
                return NotFound();
            }
            return Ok(updatedCourse);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
                       var isDeleted = await _courseService.DeleteCourse(id);
            if (!isDeleted)
            {
                return NotFound();
            }
            return Ok(true);
        }
    }
}
