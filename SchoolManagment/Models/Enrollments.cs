using System.Text.Json.Serialization;

namespace SchoolManagment.Models
{
    public class Enrollments
    {
        public int Id { get; set; } 
        public int StudentId { get; set; }

        public Students ?Student { get; set; }
        public int CourseID { get; set; }

        [JsonIgnore]
        public Courses ?Course { get; set; }

        public char Grade { get; set; } 
    }
}
