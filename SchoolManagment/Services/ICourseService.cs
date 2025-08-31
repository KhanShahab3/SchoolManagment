using SchoolManagment.Models;
using SchoolManagment.Models.ModelsDTO;

namespace SchoolManagment.Services
{
    public interface ICourseService
    {
        Task<List<CourseGetDTO>> GetAllCourses();
        Task<Courses> GetCourse(int id);
        Task<Courses> AddCourse(Courses course);
        Task<Courses> UpdateCourse(Courses course);
        Task<bool> DeleteCourse(int id);
    }
}
