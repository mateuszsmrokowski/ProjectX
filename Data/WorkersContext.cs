using Microsoft.EntityFrameworkCore;
using ProjectX.Models;

namespace ProjectX.Data
{
    public class WorkersContext: DbContext
    {
        public WorkersContext(DbContextOptions<WorkersContext> options) : base(options)
        {
        }

        public DbSet<Workers> Workers { get; set; }
        public DbSet<Days> Days { get; set; }
        public DbSet<DaysOfWork> DaysOfWork { get; set; }
    }
}
