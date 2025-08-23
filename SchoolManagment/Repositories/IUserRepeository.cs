using SchoolManagment.Models;

namespace SchoolManagment.Repositories
{
    public interface IUserRepeository
    {
        Task<List<Users>> GetAllUsers();
        Task<Users> GetUsersById(int id);
        Task<Users> AddUsers(Users users);
        Task<Users>UpdateUsers(Users users);
        Task<bool>DeleteUser(int id);   
    }
}
