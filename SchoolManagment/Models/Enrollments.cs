namespace SchoolManagment.Models
{
    public class Enrollments
    {
        public int Id { get; set; } 
        public int StudentId { get; set; }
        public int CourseID { get; set; }

        public char Grade { get; set; } 
    }
}
