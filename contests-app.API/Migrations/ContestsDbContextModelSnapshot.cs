﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using contests_app.API.Persistence;

#nullable disable

namespace contests_app.API.Migrations
{
    [DbContext(typeof(ContestsDbContext))]
    partial class ContestsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("contests_app.API.Persistence.Entities.CaseEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uuid");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Cases");
                });

            modelBuilder.Entity("contests_app.API.Persistence.Entities.EvaluationEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Comment")
                        .HasColumnType("text");

                    b.Property<Guid>("EvaluatorId")
                        .HasColumnType("uuid");

                    b.Property<int>("Score")
                        .HasColumnType("integer");

                    b.Property<Guid>("TeamId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("EvaluatorId");

                    b.HasIndex("TeamId");

                    b.ToTable("Evaluations", (string)null);
                });

            modelBuilder.Entity("contests_app.API.Persistence.Entities.TeamEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("SelectedCaseId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId")
                        .IsUnique();

                    b.HasIndex("SelectedCaseId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("contests_app.API.Persistence.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Avatar")
                        .HasColumnType("text");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsMentor")
                        .HasColumnType("boolean");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SurName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("TeamId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = new Guid("dfdee906-a518-4379-b4c6-3f89d1b1f062"),
                            Avatar = "https://material.angular.io/assets/img/examples/shiba1.jpg",
                            IsAdmin = false,
                            IsMentor = true,
                            Login = "mentor",
                            Name = "Mentor",
                            PasswordHash = "$2a$11$lH2ihOr5y5hez/zPcNcVs.n4qgYeMntixbi.Er2aTSgCQj2AchNZO",
                            SurName = "Mentor"
                        },
                        new
                        {
                            Id = new Guid("7955e387-9445-477d-b0cf-75ebaca2599a"),
                            Avatar = "https://material.angular.io/assets/img/examples/shiba1.jpg",
                            IsAdmin = true,
                            IsMentor = false,
                            Login = "admin",
                            Name = "Admin",
                            PasswordHash = "$2a$11$wvIRl2D9DZjDQ6c5oLUblu8BjbJ7r5W.IKQpzr3mS6/lS4wIGBTke",
                            SurName = "Admin"
                        },
                        new
                        {
                            Id = new Guid("a3873af6-b340-4665-981b-0a2800f78dc5"),
                            Avatar = "https://material.angular.io/assets/img/examples/shiba1.jpg",
                            IsAdmin = false,
                            IsMentor = false,
                            Login = "user",
                            Name = "User",
                            PasswordHash = "$2a$11$LNtSiy9Doajy0WGzfkIKNu7.LFdBdDbdEP8hywD6cHtJ8uD3j7zua",
                            SurName = "User"
                        });
                });

            modelBuilder.Entity("contests_app.API.Persistence.Entities.CaseEntity", b =>
                {
                    b.HasOne("contests_app.API.Persistence.Entities.UserEntity", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("contests_app.API.Persistence.Entities.EvaluationEntity", b =>
                {
                    b.HasOne("contests_app.API.Persistence.Entities.UserEntity", "Evaluator")
                        .WithMany()
                        .HasForeignKey("EvaluatorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("contests_app.API.Persistence.Entities.TeamEntity", "Team")
                        .WithMany("Evaluations")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Evaluator");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("contests_app.API.Persistence.Entities.TeamEntity", b =>
                {
                    b.HasOne("contests_app.API.Persistence.Entities.UserEntity", "Owner")
                        .WithOne("OwnedTeam")
                        .HasForeignKey("contests_app.API.Persistence.Entities.TeamEntity", "OwnerId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.HasOne("contests_app.API.Persistence.Entities.CaseEntity", "SelectedCase")
                        .WithMany()
                        .HasForeignKey("SelectedCaseId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Owner");

                    b.Navigation("SelectedCase");
                });

            modelBuilder.Entity("contests_app.API.Persistence.Entities.UserEntity", b =>
                {
                    b.HasOne("contests_app.API.Persistence.Entities.TeamEntity", "Team")
                        .WithMany("Members")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Team");
                });

            modelBuilder.Entity("contests_app.API.Persistence.Entities.TeamEntity", b =>
                {
                    b.Navigation("Evaluations");

                    b.Navigation("Members");
                });

            modelBuilder.Entity("contests_app.API.Persistence.Entities.UserEntity", b =>
                {
                    b.Navigation("OwnedTeam")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
