using SchoolManagment.Models;
using SchoolManagment.Repositories;

namespace SchoolManagment.Services
{
    public class UserService:IUserService
    {
        private readonly IUserRepeository _userRepository;
        public UserService(IUserRepeository userRepository)
        {
            _userRepository = userRepository;
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
            return await _userRepository.AddUsers(users);
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
