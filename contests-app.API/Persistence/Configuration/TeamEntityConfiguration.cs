using contests_app.API.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace contests_app.API.Persistence.Configuration
{
    public class TeamEntityConfiguration : IEntityTypeConfiguration<TeamEntity>
    {
        public void Configure(EntityTypeBuilder<TeamEntity> builder)
        {
            builder.HasKey(u => u.Id);

            builder.HasOne(t => t.Owner)
                   .WithOne(u => u.OwnedTeam)
                   .HasForeignKey<TeamEntity>(t => t.OwnerId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(t => t.Members)
                   .WithOne(u => u.Team)
                   .HasForeignKey(u => u.TeamId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
