using BlazorGettingStarted.App.Services;
using BlazorGettingStarted.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGettingStarted.App.Components
{
    public partial class AddEmployeeDialog
    {
        /* At the time of component initalization when data is being bound to, the data required for binding cannot be null. 
           So for data binding to work correctly we provide some default values to the objects fields*/
        public Employee Employee { get; set; } =
            new Employee { RegionId = 1, JobCategoryId = 1, BirthDate = DateTime.Now, JoinedDate = DateTime.Now };

       
        // component will work with the data service, to allow for data to be saved to back-end.
        [Inject]
        public IEmployeeDataService EmployeeDataService { get; set; }

        public bool ShowDialog { get; set; } //flag for if component is visible or not

        public void Show()
        {
            ResetDialog();
            ShowDialog = true;
            StateHasChanged(); //explicitly tell Blazor to refresh UI
        }

        public void Close() //called in markup
        {
            ShowDialog = false;
            StateHasChanged(); //explicitly tell Blazor to refresh UI
        }

        private void ResetDialog()
        {
            Employee = new Employee { RegionId = 1, JobCategoryId = 1, BirthDate = DateTime.Now, JoinedDate = DateTime.Now };
        }

        protected async Task HandleValidSubmit()
        {
            await EmployeeDataService.AddEmployee(Employee);
            ShowDialog = false;

            StateHasChanged();
        }
    }
}
