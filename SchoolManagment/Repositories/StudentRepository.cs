using Microsoft.EntityFrameworkCore;
using SchoolManagment.AppDbContext;
using SchoolManagment.Models;

namespace SchoolManagment.Repositories
{
    public class StudentRepository: IStudentRepository
    {
        private readonly AppDb _appDb;
        public StudentRepository(AppDb appDb)
        {
            _appDb = appDb;
        }
        public async Task<List<Students>> GetStudents()
        {
            return await _appDb.Students.ToListAsync();
            
        }
        public async Task<Students>GetStudentById(int id)
        {
            return await _appDb.Students.FindAsync(id);
        }
        public async Task<Students>AddStudent(Students students)
        {
            _appDb.Students.Add(students);
           await _appDb.SaveChangesAsync();
            return students;
        }
        public async Task<Students> UpdateStudent(Students students)
        {
            var student = await _appDb.Students.FindAsync(students.Id);
            if (student == null)
            {
                return null;
            }
            student.UserId = students.UserId;
            student.EnrollmentDate = students.EnrollmentDate;
            return student;
        }
        public async Task<bool>DeleteStudent(int id)
        {
            var student = await _appDb.Students.FindAsync(id);
            if (student == null)
            {
                return false;
            }
            _appDb.Students.Remove(student);
            await _appDb.SaveChangesAsync();
            return true;
        }

    }
}
