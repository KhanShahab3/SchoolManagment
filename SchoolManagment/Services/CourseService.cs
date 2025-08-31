using SchoolManagment.Models;
using SchoolManagment.Models.ModelsDTO;
using SchoolManagment.Repositories;

namespace SchoolManagment.Services
{
    public class CourseService:ICourseService
    {
        private readonly ICourseRepository _coursesRepository;
        public CourseService(ICourseRepository coursesRepository)
        {
            _coursesRepository = coursesRepository;
        }
        public async Task<List<CourseGetDTO>> GetAllCourses()
        {
            var courses= await _coursesRepository.GetCourses();
            if(courses==null||courses.Count==0)
            {
                return new List<CourseGetDTO>();
            }
            return courses;
        }
        public async Task<Courses> GetCourse(int id)
        {
            var course= await _coursesRepository.GetCourseById(id);
            if(course==null)
            {
                return null;
            }
            return course;
        }
        public async Task<Courses> AddCourse(Courses course)
        {
            return await _coursesRepository.AddCourse(course);
        }
        public async Task<Courses> UpdateCourse(Courses course)
        {
            return await _coursesRepository.UpdateCourse(course);
        }
        public async Task<bool> DeleteCourse(int id)
        {
            var isDeleted= await _coursesRepository.DeleteCourse(id);
            if(isDeleted)
            {
                return true;
            }
            return false;
        }
    }
}
