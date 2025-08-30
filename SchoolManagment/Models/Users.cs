using System.Text.Json.Serialization;

namespace SchoolManagment.Models
{
    public class Users
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string  Email { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
        [JsonIgnore]
       public  Teachers? Teacher { get; set; }
        [JsonIgnore]
        public  Students? Student { get; set; }


    }
}
