using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace SchoolManagment.Models
{
    public class Courses
    {
        public int Id { get; set; }
        public string Tittle { get; set; }
        public int Credits { get; set; }  
        public int TeacherId { get; set; }
      
        public Teachers ?Teacher { get; set; }
    }
}
//{
//id:6,
//tittle:"Math",
//credits:3,
//teacherId:1
//teacher:{
//id:1,
//teacherName:"John Doe",
//userId:2,
//hireDate:"2023-10-01T00:00:00"

//} is i need to pass teacher object in request body or just teacherId is enough?

///

//
//}