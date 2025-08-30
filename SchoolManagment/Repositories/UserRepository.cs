using Microsoft.EntityFrameworkCore;
using SchoolManagment.AppDbContext;
using SchoolManagment.Models;

namespace SchoolManagment.Repositories
{
    public class UserRepository:IUserRepeository
    {
        private readonly AppDb _appDb;
        public UserRepository(AppDb appDb)
        {
            _appDb=appDb;
        }

        public async Task<List<Users>> GetAllUsers()
        {
            var users = await _appDb.Users.ToListAsync();
            return users;
        }
        public async Task<Users>GetUsersById(int id)
        {
            var user=await _appDb.Users.FindAsync(id);
            return user;
        }
        public async Task<Users> AddUsers(Users users)

        {
            var user = new Users
            {
                Name = users.Name,
                Email = users.Email,
                Role = users.Role,
                Password = users.Password

            };
           _appDb.Users.Add(users);
            await _appDb.SaveChangesAsync();
            return users;

        }
        public async Task<Users> UpdateUsers(Users users)
        {
            var existingUser = await _appDb.Users.FindAsync(users.Id);
            if (existingUser == null)
            {
                return null; 
            }
            existingUser.Name = users.Name;
            existingUser.Email = users.Email;
            existingUser.Role = users.Role;
            existingUser.Password = users.Password;
            await _appDb.SaveChangesAsync();
            return existingUser;
        }
        public async Task<bool> DeleteUser(int id)
        {
            var user = await _appDb.Users.FindAsync(id);
            if (user == null)
            {
                return false; 
            }
            _appDb.Users.Remove(user);
            await _appDb.SaveChangesAsync();
            return true;
        }
    }
}
