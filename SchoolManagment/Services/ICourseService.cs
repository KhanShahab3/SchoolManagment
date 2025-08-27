using SchoolManagment.Models;

namespace SchoolManagment.Services
{
    public interface ICourseService
    {
        Task<List<Courses>> GetAllCourses();
        Task<Courses> GetCourse(int id);
        Task<Courses> AddCourse(Courses course);
        Task<Courses> UpdateCourse(Courses course);
        Task<bool> DeleteCourse(int id);
    }
}
