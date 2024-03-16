using Microsoft.EntityFrameworkCore;
using Taskscheduler.Models;

namespace Taskscheduler.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Taskschedule> Taskschedules { get; set; }
    }
}
