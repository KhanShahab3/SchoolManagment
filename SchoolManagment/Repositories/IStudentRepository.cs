using SchoolManagment.Models;

namespace SchoolManagment.Repositories
{
    public interface IStudentRepository
    {
        Task<List<Students>>GetStudents();
        Task<Students> GetStudentById(int id);
        Task<Students> AddStudent(Students students);
        Task<Students> UpdateStudent(Students students);
        Task<bool> DeleteStudent(int id);
    }
}
