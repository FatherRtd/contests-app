using contests_app.API.Persistence.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace contests_app.API.Persistence.Configuration
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(u => u.Id);

            builder.HasOne(u => u.Team)
                   .WithMany(t => t.Members)
                   .HasForeignKey(u => u.TeamId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(u => u.OwnedTeam)
                   .WithOne(t => t.Owner)
                   .HasForeignKey<TeamEntity>(t => t.OwnerId)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
