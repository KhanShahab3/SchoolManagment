using Microsoft.EntityFrameworkCore;
using SchoolManagment.AppDbContext;
using SchoolManagment.Models;

namespace SchoolManagment.Repositories
{
    public class EnrollmentRepository:IEnrollmentsRepository
    {
        private readonly AppDb _appDb;
        public EnrollmentRepository(AppDb appDb)
        {
              _appDb = appDb;
        }
        public async Task<List<Enrollments>> GetAllEnrollments()
        {
            var enrollments = await _appDb.Enrollments.
                Include(s=>s.Student).

                ToListAsync();
            return enrollments;
        }

        public async Task<Enrollments>GetEnrollmentById(int id)
        {
            var enrollment=await _appDb.Enrollments.FindAsync(id);
            return enrollment;
        }

        public async Task<Enrollments>AddEnrollment(Enrollments enrollment)
        {
            _appDb.Enrollments.AddAsync(enrollment);
            await _appDb.SaveChangesAsync();
            return enrollment;
        }
        public async Task<Enrollments>UpdateEnrollment(Enrollments enrollments)
        {
            var existingEnrollment=await _appDb.Enrollments.FindAsync(enrollments.Id);
            if (existingEnrollment == null)
            {
                return null;
            }
            existingEnrollment.StudentId = enrollments.StudentId;
            existingEnrollment.CourseID = enrollments.CourseID;
            existingEnrollment.Grade = enrollments.Grade;
            await _appDb.SaveChangesAsync();
            return existingEnrollment;
        }
        public async Task<bool>DeleteEnrollment(int id)
        {
            var enrollment = await _appDb.Enrollments.FindAsync(id);
            if (enrollment == null)
            {
                return false;
            }
            _appDb.Enrollments.Remove(enrollment);
            await _appDb.SaveChangesAsync();
            return true;
        }

        public async Task<List<Enrollments>> GetEnrollmentsByCourseId(int courseId)
        {
            var enrollments=await _appDb.Enrollments.
                Where(e=>e.CourseID==courseId).
                Include(s=>s.Student).
                ToListAsync();
            return enrollments;
        }


    }
}
