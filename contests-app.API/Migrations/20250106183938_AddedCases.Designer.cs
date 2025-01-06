﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using contests_app.API.Persistence;

#nullable disable

namespace contests_app.API.Migrations
{
    [DbContext(typeof(ContestsDbContext))]
    [Migration("20250106183938_AddedCases")]
    partial class AddedCases
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                            Id = new Guid("a269c122-173a-40fc-9251-56974558b05b"),
                            Avatar = "https://material.angular.io/assets/img/examples/shiba1.jpg",
                            IsAdmin = false,
                            IsMentor = true,
                            Login = "mentor",
                            Name = "Mentor",
                            PasswordHash = "$2a$11$OubmklCEtei8LtdFcrKrXe4a5.h/zlw2l66DRl1ZV4m2cjjyrbcGG",
                            SurName = "Mentor"
                        },
                        new
                        {
                            Id = new Guid("18070b67-8ec7-43ba-846c-4bac2e806584"),
                            Avatar = "https://material.angular.io/assets/img/examples/shiba1.jpg",
                            IsAdmin = true,
                            IsMentor = false,
                            Login = "admin",
                            Name = "Admin",
                            PasswordHash = "$2a$11$C.Ul4Cx/U0/yOv2bYxR22ueNRtYYgfjMqWTAPOzruhVN/GeNLk9RO",
                            SurName = "Admin"
                        },
                        new
                        {
                            Id = new Guid("c8b7080b-5703-4844-8e51-4fb497394b51"),
                            Avatar = "https://material.angular.io/assets/img/examples/shiba1.jpg",
                            IsAdmin = false,
                            IsMentor = false,
                            Login = "user",
                            Name = "User",
                            PasswordHash = "$2a$11$uVqjFNmJ7spWSAPVXOw7TebPUsh/N3X0rQtxbjid1FjNySKwXav3K",
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
