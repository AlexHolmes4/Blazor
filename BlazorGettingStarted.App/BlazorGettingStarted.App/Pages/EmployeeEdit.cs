using BlazorGettingStarted.App.Services;
using BlazorGettingStarted.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.IO;
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

        [Inject]
        public NavigationManager NavigationManager { get; set; } //default class to allow navigation through code.
         
        [Parameter] // blazor will search for the employee ID in the Query String when this component is being invoked.
        public string EmployeeId { get; set; }

        public Employee Employee { get; set; } = new Employee(); //add or edit will databind to an employee
        public List<Region> Regions { get; set; } = new List<Region>();
        public List<JobCategory> JobCategories { get; set; } = new List<JobCategory>();

        protected string RegionId = string.Empty; //helper field for the two-way binding needed on input select
        protected string JobCategoryId = string.Empty;

        //used to store state of form/screen
        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;  //check if form already submitted or not (used in UI)

        protected override async Task OnInitializedAsync()
        {
            Saved = false; 

            Regions = (await RegionDataService.GetAllRegions()).ToList();
            JobCategories = (await JobCategoryDataService.GetAllJobCategories()).ToList();

            // for populating the Employee data on initalization; we check if page is for Add or Edit            
            int.TryParse(EmployeeId, out var employeeId);
            if(employeeId == 0) // new employee is being created
            {
                //add some defaults
                Employee = new Employee { RegionId = 1, JobCategoryId = 1, BirthDate = DateTime.Now, JoinedDate = DateTime.Now };
            }
            else
            {
                Employee = await EmployeeDataService.GetEmployeeDetails(int.Parse(EmployeeId));
            }

            RegionId = Employee.RegionId.ToString();
            JobCategoryId = Employee.JobCategoryId.ToString();
        }

        private IReadOnlyList<IBrowserFile> selectedFiles;

        private void OnInputFileChange(InputFileChangeEventArgs e)
        {
            selectedFiles = e.GetMultipleFiles();
            Message = $"(selectedFiles.Count) files(s) selected";
            StateHasChanged();
        }

        protected async Task HandleValidSubmit()
        {
            //assign to employee object the values we bound to on the input select's (this was due to limitation on binding to IEnumerables). 
            Employee.RegionId = int.Parse(RegionId);
            Employee.JobCategoryId = int.Parse(JobCategoryId);

            Saved = false;

            if (Employee.EmployeeId == 0) //new
            {
                if (selectedFiles != null) // take first image
                {
                    var file = selectedFiles[0];
                    Stream stream = file.OpenReadStream();
                    MemoryStream ms = new MemoryStream();
                    await stream.CopyToAsync(ms);
                    stream.Close();

                    Employee.ImageName = file.Name;
                    Employee.ImageContent = ms.ToArray();
                }
                var addedemployee = await EmployeeDataService.AddEmployee(Employee);
                if (addedemployee != null)
                {
                    StatusClass = "alert-success";
                    Message = "New employee added successfully.";
                    Saved = true;
                }
                else
                {
                    StatusClass = "alert-danger";
                    Message = "Something went wrong adding the new employee. Please try again.";
                    Saved = false;
                }
            }
            else
            {
                await EmployeeDataService.UpdateEmployee(Employee);
                StatusClass = "alert-success";
                Message = "Employee updated successfully.";
                Saved = true;
            }
        }

        protected void HandleInvalidSubmit()
        {
            StatusClass = "alert-danger";
            Message = "There are some validation errors. Please try again.";
        }

        protected  async Task DeleteEmployee()
        {
            await EmployeeDataService.DeleteEmployee(Employee.EmployeeId);

            StatusClass = "alert-success";
            Message = "Deleted successfully";

            Saved = true;
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/employeeoverview");
        }
    }
}
