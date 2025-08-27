namespace SchoolManagment.Models
{
    public class Users
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string  Email { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }  
        
        Teachers? Teacher { get; set; }
        Students? Student { get; set; }


    }
}
