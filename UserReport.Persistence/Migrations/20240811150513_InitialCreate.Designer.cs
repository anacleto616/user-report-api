﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using UserReport.Persistence.Contexts;

#nullable disable

namespace UserReport.Persistence.Migrations
{
    [DbContext(typeof(UserReportContext))]
    [Migration("20240811150513_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("UserReport.Domain.Coordinates", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Latitude")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Longitude")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Coordinates");
                });

            modelBuilder.Entity("UserReport.Domain.DateOfBirth", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Age")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("DateOfBirths");
                });

            modelBuilder.Entity("UserReport.Domain.Identification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Identifications");
                });

            modelBuilder.Entity("UserReport.Domain.Info", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Page")
                        .HasColumnType("integer");

                    b.Property<int>("Results")
                        .HasColumnType("integer");

                    b.Property<string>("Seed")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Infos");
                });

            modelBuilder.Entity("UserReport.Domain.Location", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("CoordinatesId")
                        .HasColumnType("uuid");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Postcode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("StreetId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TimezoneId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CoordinatesId");

                    b.HasIndex("StreetId");

                    b.HasIndex("TimezoneId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("UserReport.Domain.Login", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Md5")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Sha1")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Sha256")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Uuid")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Logins");
                });

            modelBuilder.Entity("UserReport.Domain.Name", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("First")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Last")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Names");
                });

            modelBuilder.Entity("UserReport.Domain.Picture", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Large")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Medium")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Thumbnail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Pictures");
                });

            modelBuilder.Entity("UserReport.Domain.Registered", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Age")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Registereds");
                });

            modelBuilder.Entity("UserReport.Domain.Street", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Number")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Streets");
                });

            modelBuilder.Entity("UserReport.Domain.Timezone", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Offset")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Timezones");
                });

            modelBuilder.Entity("UserReport.Domain.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Cell")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("DobId")
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("Id1")
                        .HasColumnType("uuid");

                    b.Property<Guid>("LocationId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("LoginId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("NameId")
                        .HasColumnType("uuid");

                    b.Property<string>("Nat")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("PictureId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RegisteredId")
                        .HasColumnType("uuid");

                    b.HasKey("UserId");

                    b.HasIndex("DobId");

                    b.HasIndex("Id1");

                    b.HasIndex("LocationId");

                    b.HasIndex("LoginId");

                    b.HasIndex("NameId");

                    b.HasIndex("PictureId");

                    b.HasIndex("RegisteredId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("UserReport.Domain.Location", b =>
                {
                    b.HasOne("UserReport.Domain.Coordinates", "Coordinates")
                        .WithMany()
                        .HasForeignKey("CoordinatesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UserReport.Domain.Street", "Street")
                        .WithMany()
                        .HasForeignKey("StreetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UserReport.Domain.Timezone", "Timezone")
                        .WithMany()
                        .HasForeignKey("TimezoneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Coordinates");

                    b.Navigation("Street");

                    b.Navigation("Timezone");
                });

            modelBuilder.Entity("UserReport.Domain.User", b =>
                {
                    b.HasOne("UserReport.Domain.DateOfBirth", "Dob")
                        .WithMany()
                        .HasForeignKey("DobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UserReport.Domain.Identification", "Id")
                        .WithMany()
                        .HasForeignKey("Id1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UserReport.Domain.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UserReport.Domain.Login", "Login")
                        .WithMany()
                        .HasForeignKey("LoginId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UserReport.Domain.Name", "Name")
                        .WithMany()
                        .HasForeignKey("NameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UserReport.Domain.Picture", "Picture")
                        .WithMany()
                        .HasForeignKey("PictureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UserReport.Domain.Registered", "Registered")
                        .WithMany()
                        .HasForeignKey("RegisteredId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dob");

                    b.Navigation("Id");

                    b.Navigation("Location");

                    b.Navigation("Login");

                    b.Navigation("Name");

                    b.Navigation("Picture");

                    b.Navigation("Registered");
                });
#pragma warning restore 612, 618
        }
    }
}
