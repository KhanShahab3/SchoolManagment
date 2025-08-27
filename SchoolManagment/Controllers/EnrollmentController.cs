using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagment.Models;
using SchoolManagment.Services;

namespace SchoolManagment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentService _enrollmentService;
        public EnrollmentController(IEnrollmentService enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEnrollments()
        {
            var enrollments = await _enrollmentService.GetEnrollments();
            if (enrollments.Count == 0)
            {
                return NotFound();
            }
            return Ok(enrollments);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEnrollmentById(int id)
        {
            var enrollment = await _enrollmentService.GetEnrollment(id);
            if (enrollment == null)
            {
                return NotFound();
            }
            return Ok(enrollment);
        }
        [HttpPost]
        public async Task<IActionResult> AddEnrollment(Models.Enrollments enrollment)
        {
            var newEnrollment = await _enrollmentService.AddEnrollment(enrollment);
            if (newEnrollment != null)
            {
                return Ok(newEnrollment);
            }
            return BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult>UpdateEnrololoment(Enrollments enrollments)
        {
            var updateEnrollment=await _enrollmentService.UpdateEnrollment(enrollments);
            if(updateEnrollment==null)
            {
                return NotFound();
            }
            return Ok(updateEnrollment);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteEnrollment(int id)
        {
            var isDeleted=await _enrollmentService.DeleteEnrollment(id);
            if(!isDeleted)
            {
                return NotFound();
            }
            return Ok(true);
        }
    }
}
