using System.Runtime.CompilerServices;
using contests_app.API.Persistence.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using contests_app.API.Services.Auth;

namespace contests_app.API.Persistence.Configuration
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        private readonly IPasswordHasher _passwordHasher;

        public UserEntityConfiguration()
        {
            _passwordHasher = new PasswordHasher();
        }

        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Avatar).IsRequired(false);

            builder.HasOne(u => u.Team)
                   .WithMany(t => t.Members)
                   .HasForeignKey(u => u.TeamId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(u => u.OwnedTeam)
                   .WithOne(t => t.Owner)
                   .HasForeignKey<TeamEntity>(t => t.OwnerId)
                   .OnDelete(DeleteBehavior.SetNull);

            var defaultUser = new UserEntity
            {
                Id = Guid.NewGuid(),
                Name = "User",
                SurName = "User",
                Login = "user",
                PasswordHash = _passwordHasher.Generate("user"),
                IsAdmin = false,
                IsMentor = false,
                Avatar = "https://material.angular.io/assets/img/examples/shiba1.jpg",
            };

            var defaultAdmin = new UserEntity
            {
                Id = Guid.NewGuid(),
                Name = "Admin",
                SurName = "Admin",
                Login = "admin",
                PasswordHash = _passwordHasher.Generate("admin"),
                IsAdmin = true,
                IsMentor = false,
                Avatar = "https://material.angular.io/assets/img/examples/shiba1.jpg",
            };

            var defaultMentor = new UserEntity
            {
                Id = Guid.NewGuid(),
                Name = "Mentor",
                SurName = "Mentor",
                Login = "mentor",
                PasswordHash = _passwordHasher.Generate("mentor"),
                IsAdmin = false,
                IsMentor = true,
                Avatar = "https://material.angular.io/assets/img/examples/shiba1.jpg",
            };

            builder.HasData(defaultMentor);
            builder.HasData(defaultAdmin);
            builder.HasData(defaultUser);
        }
    }
}
