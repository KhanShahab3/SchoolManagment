using SchoolManagment.Models;

namespace SchoolManagment.Repositories
{
    public interface IEnrollmentsRepository
    {
        Task<List<Enrollments>> GetAllEnrollments();
        Task<Enrollments> GetEnrollmentById(int id);
        Task<Enrollments>AddEnrollment(Enrollments enrollment);
        Task<Enrollments>UpdateEnrollment(Enrollments enrollment);
        Task<bool>DeleteEnrollment(int id);
    }
}
