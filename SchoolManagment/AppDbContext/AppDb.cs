using Microsoft.EntityFrameworkCore;
using SchoolManagment.Models;

namespace SchoolManagment.AppDbContext
{
    public class AppDb:DbContext
    {
        public AppDb(DbContextOptions<AppDb> options) : base(options)
        {
        }
        public DbSet<Users>Users { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Enrollments> Enrollments { get; set; }
        public DbSet<Teachers> Teachers { get; set; }
        public DbSet<Students> Students { get; set; }

    }
}
