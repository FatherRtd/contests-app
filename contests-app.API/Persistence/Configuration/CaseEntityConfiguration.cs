using contests_app.API.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace contests_app.API.Persistence.Configuration
{
    public class CaseEntityConfiguration : IEntityTypeConfiguration<CaseEntity>
    {
        public void Configure(EntityTypeBuilder<CaseEntity> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasOne(c => c.Owner)
                   .WithMany()
                   .HasForeignKey(c => c.OwnerId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
