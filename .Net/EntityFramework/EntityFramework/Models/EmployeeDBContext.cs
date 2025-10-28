using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Models
{
    public class EmployeeDBContext : DbContext
    {
        public EmployeeDBContext(DbContextOptions options) : base(options) { 
            
        }

        public DbSet<Employee> Employees2 { get; set; }
    }
}
