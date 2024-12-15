using contests_app.API.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace contests_app.API.Persistence
{
    public class ContestsDbContext : DbContext
    {
        public ContestsDbContext(DbContextOptions<ContestsDbContext> options) : base(options) { }

        public DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ContestsDbContext).Assembly);
        }
    }
}
