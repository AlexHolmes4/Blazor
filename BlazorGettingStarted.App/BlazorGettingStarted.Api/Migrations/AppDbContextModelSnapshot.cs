﻿// <auto-generated />
using System;
using BlazorGettingStarted.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BlazorGettingStarted.Api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BlazorGettingStarted.Shared.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comment")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ExitDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("JobCategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("JoinedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<int>("MaritalStatus")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RegionId")
                        .HasColumnType("int");

                    b.Property<bool>("Smoker")
                        .HasColumnType("bit");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Zip")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.HasIndex("JobCategoryId");

                    b.HasIndex("RegionId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeId = 1,
                            BirthDate = new DateTime(1979, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "Brussels",
                            Comment = "Lorem Ipsum",
                            Email = "bethany@bethanyspieshop.com",
                            FirstName = "Bethany",
                            Gender = 1,
                            JobCategoryId = 1,
                            JoinedDate = new DateTime(2015, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastName = "Smith",
                            Latitude = 50.850299999999997,
                            Longitude = 4.3517000000000001,
                            MaritalStatus = 1,
                            PhoneNumber = "324777888773",
                            RegionId = 1,
                            Smoker = false,
                            Street = "Grote Markt 1",
                            Zip = "1000"
                        },
                        new
                        {
                            EmployeeId = 2,
                            BirthDate = new DateTime(1979, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "Antwerp",
                            Comment = "Lorem Ipsum",
                            Email = "gill@bethanyspieshop.com",
                            FirstName = "Gill",
                            Gender = 0,
                            JobCategoryId = 1,
                            JoinedDate = new DateTime(2017, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastName = "Cleeren",
                            Latitude = 50.850299999999997,
                            Longitude = 4.3517000000000001,
                            MaritalStatus = 0,
                            PhoneNumber = "33999909923",
                            RegionId = 2,
                            Smoker = false,
                            Street = "New Street",
                            Zip = "2000"
                        });
                });

            modelBuilder.Entity("BlazorGettingStarted.Shared.JobCategory", b =>
                {
                    b.Property<int>("JobCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("JobCategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("JobCategoryId");

                    b.ToTable("JobCategories");

                    b.HasData(
                        new
                        {
                            JobCategoryId = 1,
                            JobCategoryName = "Sales"
                        },
                        new
                        {
                            JobCategoryId = 2,
                            JobCategoryName = "Marketing"
                        },
                        new
                        {
                            JobCategoryId = 3,
                            JobCategoryName = "Management"
                        },
                        new
                        {
                            JobCategoryId = 4,
                            JobCategoryName = "Store staff"
                        },
                        new
                        {
                            JobCategoryId = 5,
                            JobCategoryName = "Finance"
                        },
                        new
                        {
                            JobCategoryId = 6,
                            JobCategoryName = "Warehouse"
                        },
                        new
                        {
                            JobCategoryId = 7,
                            JobCategoryName = "IT"
                        },
                        new
                        {
                            JobCategoryId = 8,
                            JobCategoryName = "HR"
                        },
                        new
                        {
                            JobCategoryId = 9,
                            JobCategoryName = "Procurement"
                        });
                });

            modelBuilder.Entity("BlazorGettingStarted.Shared.Region", b =>
                {
                    b.Property<int>("RegionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RegionId");

                    b.ToTable("Regions");

                    b.HasData(
                        new
                        {
                            RegionId = 1,
                            Name = "Western Australia"
                        },
                        new
                        {
                            RegionId = 2,
                            Name = "New South Wales"
                        },
                        new
                        {
                            RegionId = 3,
                            Name = "Queensland"
                        },
                        new
                        {
                            RegionId = 4,
                            Name = "Tasmania"
                        },
                        new
                        {
                            RegionId = 5,
                            Name = "South Australia"
                        },
                        new
                        {
                            RegionId = 6,
                            Name = "Victoria"
                        },
                        new
                        {
                            RegionId = 7,
                            Name = "Northern Territory"
                        },
                        new
                        {
                            RegionId = 8,
                            Name = "France"
                        },
                        new
                        {
                            RegionId = 9,
                            Name = "Brazil"
                        });
                });

            modelBuilder.Entity("BlazorGettingStarted.Shared.Employee", b =>
                {
                    b.HasOne("BlazorGettingStarted.Shared.JobCategory", "JobCategory")
                        .WithMany()
                        .HasForeignKey("JobCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlazorGettingStarted.Shared.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JobCategory");

                    b.Navigation("Region");
                });
#pragma warning restore 612, 618
        }
    }
}
