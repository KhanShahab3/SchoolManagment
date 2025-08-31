namespace SchoolManagment.Models.ModelsDTO
{
    public class CourseGetDTO
    {
        public int Id { get; set; }
        public string Tittle { get; set; }
        public int Credits { get; set; }
        public int TeacherId { get; set; }

        public string TeacherName { get; set; } 
    }
}
