using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagment.Models.ModelsDTO;
using SchoolManagment.Services;

namespace SchoolManagment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
      private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("login")]
        public async Task<IActionResult>  Login( Auth auth)
        {
            try
            {
                var token = await _authService.Authenticate(auth);

                if (token == null)
                    return Unauthorized("Invalid username or password");

                return Ok(new { data = token });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "error occured while creating token" });

            }
        }
    }
}
