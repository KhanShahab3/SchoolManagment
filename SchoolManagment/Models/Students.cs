namespace SchoolManagment.Models
{
    public class Students
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string StudentName {  get; set; }
        public Users? User { get; set; }
        public DateTime EnrollmentDate { get; set; }
    }
}
