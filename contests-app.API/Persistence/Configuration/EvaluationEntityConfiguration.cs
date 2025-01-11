using contests_app.API.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace contests_app.API.Persistence.Configuration
{
    public class EvaluationEntityConfiguration : IEntityTypeConfiguration<EvaluationEntity>
    {
        public void Configure(EntityTypeBuilder<EvaluationEntity> builder)
        {
            builder.ToTable("Evaluations");

            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.Team)
                   .WithMany(t => t.Evaluations)
                   .HasForeignKey(e => e.TeamId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Evaluator)
                   .WithMany()
                   .HasForeignKey(e => e.EvaluatorId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
