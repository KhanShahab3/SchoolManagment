using System.Text.Json.Serialization;

namespace SchoolManagment.Models
{
    public class Teachers
    {
        public int Id { get; set; }
        public string TeacherName { get; set; }
        public int UserId { get; set; }

        [JsonIgnore]
        public Users? User { get; set; }
        public DateTime HireDate { get; set; }
        [JsonIgnore]
        public List<Courses>? Courses { get; set; }

        
    }
}
