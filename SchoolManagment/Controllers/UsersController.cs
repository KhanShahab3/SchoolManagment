using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagment.Models;
using SchoolManagment.Services;

namespace SchoolManagment.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(Users users)
        {
            var newUser = await _userService.AddUser(users);
            return Ok(newUser);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteUser(int id)
        {
            var isDeleted=await _userService.DeleteUser(id);
            if (!isDeleted)
            {
             return NotFound();
            }
            else
            {
             return Ok(true);
            }
            
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUser(Users users)
        {
            var updatedUser = await _userService.UpdateUser(users);
            if (updatedUser == null)
            {
                return NotFound();
            }
            return Ok(updatedUser);
        }
    }
}
