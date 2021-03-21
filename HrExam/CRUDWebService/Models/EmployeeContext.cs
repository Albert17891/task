using Microsoft.EntityFrameworkCore;

namespace CRUDWebService.Models
{
    public class EmployeeContext:DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options) { }

        public DbSet<employee> Employees { get; set; }
    }
}
