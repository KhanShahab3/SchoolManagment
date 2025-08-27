using SchoolManagment.Models;
using SchoolManagment.Repositories;

namespace SchoolManagment.Services
{
    public class TeacherService:ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;
        public TeacherService(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }
        public async Task<Teachers>AddTeacher(Teachers teachers)
        {
            var teacher = await _teacherRepository.AddTeacher(teachers);
            return teacher;
        }
        public async Task<List<Teachers>> GetTeachers()
        {
            var teachers = await _teacherRepository.GetAllTeachers();
            if (teachers == null || teachers.Count == 0)
            {
                return new List<Teachers>();
            }
            return teachers;
        }
        public async Task<Teachers>GetTeacher(int id)
        {
            var teacher = await _teacherRepository.GetTeacherById(id);
            if (teacher == null)
            {
                return null;
            }
            return teacher;
        }
        public async Task<Teachers>UpdateTeacher(Teachers teachers)
        {
            var updatedTeacher = await _teacherRepository.UpdateTeacher(teachers);
            return updatedTeacher;
        }
        public async Task<bool>DeleteTeacher(int id)
        {
            var isDeleted = await _teacherRepository.DeleteTeacher(id);
            return isDeleted;
        }
    }
}
