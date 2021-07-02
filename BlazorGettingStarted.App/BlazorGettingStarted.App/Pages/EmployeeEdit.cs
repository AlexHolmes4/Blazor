using BlazorGettingStarted.App.Services;
using BlazorGettingStarted.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGettingStarted.App.Pages
{
    // this class used to work with employees; add new ones and update existing; data exposes through service
    public partial class EmployeeEdit
    {
        [Inject]
        public IEmployeeDataService EmployeeDataService { get; set; }

        [Inject]
        public IRegionDataService RegionDataService { get; set; }

        [Inject]
        public IJobCategoryDataService JobCategoryDataService { get; set; }
         
        [Parameter] // blazor will search for the employee ID in the Query String when this component is being invoked.
        public string EmployeeId { get; set; }

        public Employee Employee { get; set; } = new Employee(); //add or edit will databind to an employee
        public List<Region> Regions { get; set; } = new List<Region>();
        public List<JobCategory> JobCategories { get; set; } = new List<JobCategory>();

        protected string RegionId = string.Empty; //helper field for the two-way binding needed on input select
        protected string JobCategoryId = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            Regions = (await RegionDataService.GetAllRegions()).ToList();
            Employee = await EmployeeDataService.GetEmployeeDetails(int.Parse(EmployeeId));
            JobCategories = (await JobCategoryDataService.GetAllJobCategories()).ToList();

            RegionId = Employee.RegionId.ToString();
            JobCategoryId = Employee.JobCategoryId.ToString();
        }
    }
}
