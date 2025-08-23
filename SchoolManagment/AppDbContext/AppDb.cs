using Microsoft.EntityFrameworkCore;

namespace SchoolManagment.AppDbContext
{
    public class AppDb:DbContext
    {
        public AppDb(DbContextOptions<AppDb> options) : base(options)
        {
        }
    }
}
