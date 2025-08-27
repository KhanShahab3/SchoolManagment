namespace SchoolManagment.Models
{
    public class Teachers
    {
        public int Id { get; set; }
        public string TeacherName {  get; set; }
       public int UserId { get; set; }  
       public Users? User { get; set; }
        public DateTime HireDate { get; set; }
    }
}
