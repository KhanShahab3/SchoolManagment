using Microsoft.IdentityModel.Tokens;
using SchoolManagment.Models;
using SchoolManagment.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SchoolManagment.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly IConfiguration _configuration;
        public UserService(IUserRepository userRepository,
            IStudentRepository studentRepository,
            ITeacherRepository teacherRepository,
            IConfiguration configuration
            )
        {
            _userRepository = userRepository;
            _studentRepository = studentRepository;
            _teacherRepository = teacherRepository;
            _configuration = configuration;
        }
        public async Task<List<Users>> GetAllUsers()
        {
            return await _userRepository.GetAllUsers();
        }
        public async Task<Users> GetUserById(int id)
        {
            return await _userRepository.GetUsersById(id);
        }
        public async Task<Users> AddUser(Users users)
        {
            var createdUser = await _userRepository.AddUsers(users);
            if (createdUser != null && createdUser.Role == "Student")
            {
                var student = new Students
                {
                    UserId = createdUser.Id,
                    StudentName = createdUser.Name,
                    EnrollmentDate = DateTime.Now

                };
                await _studentRepository.AddStudent(student);

            }
            else if (createdUser != null && createdUser.Role == "Teacher")
            {

                var teacher = new Teachers
                {
                    UserId = createdUser.Id,
                    TeacherName = createdUser.Name,
                    HireDate = DateTime.Now
                };
                await _teacherRepository.AddTeacher(teacher);
            }


            return createdUser;


        }
        public async Task<Users> UpdateUser(Users users)
        {
            return await _userRepository.UpdateUsers(users);
        }
        public async Task<bool> DeleteUser(int id)
        {
            return await _userRepository.DeleteUser(id);
        }

       
    }

}
