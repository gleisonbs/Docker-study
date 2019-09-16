using Microsoft.EntityFrameworkCore;

namespace SchoolRegister.Models
{
    public class StudentContext: DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        
        public StudentContext(DbContextOptions options): base(options) { }
    }
}