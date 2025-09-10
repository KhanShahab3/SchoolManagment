using SchoolManagment.Models;
using SchoolManagment.Models.ModelsDTO;

namespace SchoolManagment.Repositories
{
    public interface ICourseRepository
    {
        Task<List<CourseGetDTO>> GetCourses();
        Task<List<Courses>> GetCoursesByTeacherId(int teacherId);
        Task<Courses> GetCourseById(int id);
        Task<Courses> AddCourse(Courses course);
        Task<Courses> UpdateCourse(Courses course);
        Task<bool> DeleteCourse(int id);
    }
}
