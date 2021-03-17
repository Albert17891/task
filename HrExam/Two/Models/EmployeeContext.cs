using Microsoft.EntityFrameworkCore;

namespace Two.Models
{
    public class EmployeeContext:DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options) { }

        public DbSet<employee> Employees { get; set; }
    }
}
