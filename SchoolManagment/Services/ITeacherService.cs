using SchoolManagment.Models;

namespace SchoolManagment.Services
{
    public interface ITeacherService
    {
        Task<List<Teachers>> GetTeachers();
        Task<Teachers> GetTeacher(int id);
        Task<Teachers> AddTeacher(Teachers teachers);
        Task<Teachers> UpdateTeacher(Teachers teachers);
        Task<bool> DeleteTeacher(int id);
    }
}
