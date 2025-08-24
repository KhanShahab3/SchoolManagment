using SchoolManagment.Models;
using SchoolManagment.Repositories;

namespace SchoolManagment.Services
{
    public class StudentService:IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
            
        }
        public async Task<List<Students>> GetAllStudents()
        {
            var students = await _studentRepository.GetStudents();
            if(students==null||students.Count==0)
            {
                return new List<Students>();
            }
            return students;
        }
        public async Task<Students>GetStudent(int id)
        {
            
            var student=await _studentRepository.GetStudentById(id);
           return student;
        }
        public async Task<Students>AddStudents(Students student)
        {
            var result=await _studentRepository.AddStudent(student);
            return result;
        }
        public async Task<Students>UpdateStudent(Students student)
        {
            var updatedStudent=await _studentRepository.UpdateStudent(student); return updatedStudent;
        }
        public async Task<bool>DeleteStudent(int id)
        {
            var isDeleted=await _studentRepository.DeleteStudent(id);
            return isDeleted;
        }
    }
}
