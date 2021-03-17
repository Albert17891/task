using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace HrExam.Models
{
    public class AplicationContext:IdentityDbContext<User>
    {
        public AplicationContext(DbContextOptions<AplicationContext> options) : base(options)
        {

        }
    }
}
