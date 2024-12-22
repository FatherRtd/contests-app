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
    [Migration("20241221144615_UpdatedTeams")]
    partial class UpdatedTeams
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

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

                    b.HasKey("Id");

                    b.HasIndex("OwnerId")
                        .IsUnique();

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("contests_app.API.Persistence.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

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
                });

            modelBuilder.Entity("contests_app.API.Persistence.Entities.TeamEntity", b =>
                {
                    b.HasOne("contests_app.API.Persistence.Entities.UserEntity", "Owner")
                        .WithOne("OwnedTeam")
                        .HasForeignKey("contests_app.API.Persistence.Entities.TeamEntity", "OwnerId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("Owner");
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
