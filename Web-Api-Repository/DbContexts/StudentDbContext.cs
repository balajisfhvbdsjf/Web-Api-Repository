using Microsoft.EntityFrameworkCore;
using Web_Api_Repository.Models.Domain;

namespace Web_Api_Repository.DbContexts
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Employee> Employees { get; set; }  
    }
}
