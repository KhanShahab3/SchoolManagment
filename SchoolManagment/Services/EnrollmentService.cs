using SchoolManagment.Models;
using SchoolManagment.Repositories;

namespace SchoolManagment.Services
{
    public class EnrollmentService:IEnrollmentService
    {
        private readonly IEnrollmentsRepository _enrollmentsRepository;
        public EnrollmentService(IEnrollmentsRepository enrollmentsRepository)
        {
            _enrollmentsRepository = enrollmentsRepository;
        }
        public async Task<List<Enrollments>> GetEnrollments()
        {
            var enrollments= await _enrollmentsRepository.GetAllEnrollments();
            if(enrollments==null||enrollments.Count==0)
            {
                return new List<Enrollments>();
            }
            return enrollments;
        }
        public async Task<Enrollments> GetEnrollment(int id)
        {
            var enrollment= await _enrollmentsRepository.GetEnrollmentById(id);
            if(enrollment==null)
            {
                return null;
            }
            return enrollment;
        }
        public async Task<Enrollments> AddEnrollment(Enrollments enrollment)
        {
            return await _enrollmentsRepository.AddEnrollment(enrollment);
        }
        public async Task<Enrollments> UpdateEnrollment(Enrollments enrollment)
        {
            return await _enrollmentsRepository.UpdateEnrollment(enrollment);
        }
        public async Task<bool> DeleteEnrollment(int id)
        {
            var isDeleted= await _enrollmentsRepository.DeleteEnrollment(id);
            if(isDeleted)
            {
                return true;
            }
            return false;
        }
    }
}
