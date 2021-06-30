using System;
using BlazorGettingStarted.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorGettingStarted.Api.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<JobCategory> JobCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed categories
            modelBuilder.Entity<Region>().HasData(new Region { RegionId = 1, Name = "Western Australia" });
            modelBuilder.Entity<Region>().HasData(new Region { RegionId = 2, Name = "New South Wales" });
            modelBuilder.Entity<Region>().HasData(new Region { RegionId = 3, Name = "Queensland" });
            modelBuilder.Entity<Region>().HasData(new Region { RegionId = 4, Name = "Tasmania" });
            modelBuilder.Entity<Region>().HasData(new Region { RegionId = 5, Name = "South Australia" });
            modelBuilder.Entity<Region>().HasData(new Region { RegionId = 6, Name = "Victoria" });
            modelBuilder.Entity<Region>().HasData(new Region { RegionId = 7, Name = "Northern Territory" });
            modelBuilder.Entity<Region>().HasData(new Region { RegionId = 8, Name = "France" });
            modelBuilder.Entity<Region>().HasData(new Region { RegionId = 9, Name = "Brazil" });

            modelBuilder.Entity<JobCategory>().HasData(new JobCategory() { JobCategoryId = 1, JobCategoryName = "Sales" });
            modelBuilder.Entity<JobCategory>().HasData(new JobCategory() { JobCategoryId = 2, JobCategoryName = "Marketing" });
            modelBuilder.Entity<JobCategory>().HasData(new JobCategory() { JobCategoryId = 3, JobCategoryName = "Management" });
            modelBuilder.Entity<JobCategory>().HasData(new JobCategory() { JobCategoryId = 4, JobCategoryName = "Store staff" });
            modelBuilder.Entity<JobCategory>().HasData(new JobCategory() { JobCategoryId = 5, JobCategoryName = "Finance" });
            modelBuilder.Entity<JobCategory>().HasData(new JobCategory() { JobCategoryId = 6, JobCategoryName = "Warehouse" });
            modelBuilder.Entity<JobCategory>().HasData(new JobCategory() { JobCategoryId = 7, JobCategoryName = "IT" });
            modelBuilder.Entity<JobCategory>().HasData(new JobCategory() { JobCategoryId = 8, JobCategoryName = "HR" });
            modelBuilder.Entity<JobCategory>().HasData(new JobCategory() { JobCategoryId = 9, JobCategoryName = "Procurement" });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 1,
                RegionId = 1,
                MaritalStatus = MaritalStatus.Single,
                BirthDate = new DateTime(1979, 1, 16),
                City = "Brussels",
                Email = "bethany@bethanyspieshop.com",
                FirstName = "Bethany",
                LastName = "Smith",
                Gender = Gender.Female,
                PhoneNumber = "324777888773",
                Smoker = false,
                Street = "Grote Markt 1",
                Zip = "1000",
                JobCategoryId = 1,
                Comment = "Lorem Ipsum",
                ExitDate = null,
                JoinedDate = new DateTime(2015, 3, 1),
                Latitude = 50.8503,
                Longitude = 4.3517
            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                RegionId = 2,
                MaritalStatus = MaritalStatus.Married,
                BirthDate = new DateTime(1979, 1, 16),
                City = "Antwerp",
                Email = "gill@bethanyspieshop.com",
                EmployeeId = 2,
                FirstName = "Gill",
                LastName = "Cleeren",
                Gender = Gender.Male,
                PhoneNumber = "33999909923",
                Smoker = false,
                Street = "New Street",
                Zip = "2000",
                JobCategoryId = 1,
                Comment = "Lorem Ipsum",
                ExitDate = null,
                JoinedDate = new DateTime(2017, 12, 24),
                Latitude = 50.8503,
                Longitude = 4.3517
            });
        }
    }
}
