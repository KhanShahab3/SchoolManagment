using Microsoft.EntityFrameworkCore;
using SchoolManagment.AppDbContext;
using SchoolManagment.Models;

namespace SchoolManagment.Repositories
{
    public class CourseRepository: ICourseRepository    
    {
        private readonly AppDb _context;
        public CourseRepository(AppDb context)
        {
            _context = context;
        }
        public async Task<List<Courses>> GetCourses()
        {
            return await _context.Courses.ToListAsync();
        }
        public async Task<Courses> GetCourseById(int id)
        {
            return await _context.Courses.FindAsync(id);
        }
        public async Task<Courses> AddCourse(Courses course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            return course;
        }
        public async Task<Courses> UpdateCourse(Courses course)
        {
            var existingCourse = await _context.Courses.FindAsync(course.Id);
            if (existingCourse == null)
            {
                return null;
            }
            existingCourse.Tittle = course.Tittle;
            existingCourse.Credits = course.Credits;
            await _context.SaveChangesAsync();
            return existingCourse;
        }
        public async Task<bool> DeleteCourse(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return false;
            }
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
