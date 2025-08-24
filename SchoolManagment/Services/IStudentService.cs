using SchoolManagment.Models;

namespace SchoolManagment.Services
{
    public interface IStudentService
    {
        public  Task<List<Students>> GetAllStudents();
        public Task<Students>GetStudent(int id);
        public Task<Students>AddStudents(Students students);
        public Task<Students>UpdateStudent(Students students);
        public Task<bool>DeleteStudent(int id);
    }
}
