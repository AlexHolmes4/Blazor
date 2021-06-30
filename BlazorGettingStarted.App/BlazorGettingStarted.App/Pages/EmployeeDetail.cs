using BlazorGettingStarted.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGettingStarted.App.Pages
{
    public partial class EmployeeDetail
    {
        [Parameter]
        public string EmployeeId { get; set; }
        public Employee Employee { get; set; } = new Employee();

        protected override Task OnInitializedAsync()
        {

            InitializeRegions();
            InitializeJobCategories();
            InitializeEmployees();

            Employee = Employees.FirstOrDefault(e => e.EmployeeId == int.Parse(EmployeeId));


            return base.OnInitializedAsync();
        }

        public IEnumerable<Employee> Employees { get; set; }

        private List<Region> Regions { get; set; }

        private List<JobCategory> JobCategories { get; set; }

        private void InitializeJobCategories()
        {
            JobCategories = new List<JobCategory>()
            {
                new JobCategory{JobCategoryId = 1, JobCategoryName = "Sales"},
                new JobCategory{JobCategoryId = 2, JobCategoryName = "Marketing"},
                new JobCategory{JobCategoryId = 3, JobCategoryName = "Management"},
                new JobCategory{JobCategoryId = 4, JobCategoryName = "Store staff"},
                new JobCategory{JobCategoryId = 5, JobCategoryName = "Finance"},
                new JobCategory{JobCategoryId = 6, JobCategoryName = "Warehouse"},
                new JobCategory{JobCategoryId = 7, JobCategoryName = "IT"},
                new JobCategory{JobCategoryId = 8, JobCategoryName = "HR"},
                new JobCategory{JobCategoryId = 9, JobCategoryName = "Procurement"}
            };
        }

        private void InitializeRegions()
        {
            Regions = new List<Region>
            {
                new Region {RegionId = 1, Name = "Western Australia"},
                new Region {RegionId = 2, Name = "New South Wales"},
                new Region {RegionId = 3, Name = "Queensland"},
                new Region {RegionId = 4, Name = "Tasmania"},
                new Region {RegionId = 5, Name = "South Australia"},
                new Region {RegionId = 6, Name = "Victoria"},
                new Region {RegionId = 7, Name = "Northern Territory"}
            };
        }

        private void InitializeEmployees()
        {
            var e1 = new Employee
            {
                RegionId = 1,
                MaritalStatus = MaritalStatus.Single,
                BirthDate = new DateTime(1989, 3, 11),
                City = "Brussels",
                Email = "bethany@bethanyspieshop.com",
                EmployeeId = 1,
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
                JoinedDate = new DateTime(2015, 3, 1)
            };

            var e2 = new Employee
            {
                RegionId = 2,
                MaritalStatus = MaritalStatus.Married,
                BirthDate = new DateTime(1979, 1, 16),
                City = "Antwerp",
                Email = "gill@bethanyspieshop.com",
                EmployeeId = 2,
                FirstName = "Gill",
                LastName = "Cleeren",
                Gender = Gender.Female,
                PhoneNumber = "33999909923",
                Smoker = false,
                Street = "New Street",
                Zip = "2000",
                JobCategoryId = 1,
                Comment = "Lorem Ipsum",
                ExitDate = null,
                JoinedDate = new DateTime(2017, 12, 24)
            };
            Employees = new List<Employee> { e1, e2 };
        }
    }
}
