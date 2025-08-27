using Microsoft.EntityFrameworkCore;
using SchoolManagment.AppDbContext;
using SchoolManagment.Models;

namespace SchoolManagment.Repositories
{
    public class TeacherRepository:ITeacherRepository
    {
        private readonly AppDb _context;
        public TeacherRepository(AppDb context)
        {
            _context = context;
        }
        public async Task<Teachers> AddTeacher(Teachers teachers)
        {
             _context.Teachers.AddAsync(teachers);
            await _context.SaveChangesAsync();
            return teachers;
        }
        public async Task<Teachers>UpdateTeacher(Teachers teachers)
        {
            var teacher=await _context.Teachers.FindAsync(teachers.Id);
            if (teacher == null)
            {
                return null;
            }
            teacher.UserId= teachers.UserId;
            teacher.HireDate = teachers.HireDate;
            teacher.TeacherName = teachers.TeacherName;
            await _context.SaveChangesAsync();
            return teacher;
        }
        public async Task<List<Teachers>> GetAllTeachers()
        {
             return await _context.Teachers
                .Include(t=>t.User)
                .ToListAsync();
        }
        public async Task<Teachers> GetTeacherById(int id)
        {
            return await _context.Teachers.FindAsync(id);
        }   

        public async Task<bool>DeleteTeacher(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null)
            {
                return false;
            }
            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
