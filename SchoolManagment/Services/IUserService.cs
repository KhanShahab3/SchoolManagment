using SchoolManagment.Models;

namespace SchoolManagment.Services
{
    public interface IUserService
    {
        Task<List<Users>> GetAllUsers();
        Task<Users> GetUserById(int id);
        Task<Users> AddUser(Users users);
        Task<Users> UpdateUser(Users users);
        Task<bool> DeleteUser(int id);

    }
}
