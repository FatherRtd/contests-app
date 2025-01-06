using contests_app.API.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace contests_app.API.Persistence
{
    public class ContestsDbContext : DbContext
    {
        public ContestsDbContext(DbContextOptions<ContestsDbContext> options) : base(options) { }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<TeamEntity> Teams { get; set; }
        public DbSet<CaseEntity> Cases { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ContestsDbContext).Assembly);
        }
    }
}
