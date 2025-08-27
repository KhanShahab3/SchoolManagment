using SchoolManagment.Models;

namespace SchoolManagment.Services
{
    public interface IEnrollmentService
    {
        Task<List<Enrollments>> GetEnrollments();
        Task<Enrollments> GetEnrollment(int id);
        Task<Enrollments> AddEnrollment(Enrollments enrollment);
        Task<Enrollments> UpdateEnrollment(Enrollments enrollment);
        Task<bool> DeleteEnrollment(int id);
    }
}
