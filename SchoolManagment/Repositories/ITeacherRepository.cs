using SchoolManagment.Models;

namespace SchoolManagment.Repositories
{
    public interface ITeacherRepository
    {
        Task<List<Teachers>> GetAllTeachers();
        Task<Teachers> GetTeacherById(int id);
        Task<Teachers>AddTeacher(Teachers teachers);
        Task<Teachers> UpdateTeacher(Teachers teachers);    
        Task<bool> DeleteTeacher(int id);
    }
}
