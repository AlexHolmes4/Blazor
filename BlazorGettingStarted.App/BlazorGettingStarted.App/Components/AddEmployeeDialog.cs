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

        [Parameter] // parameter attribute used so parent component can subscribe to this callback 
        public EventCallback<bool>CloseEventCallback { get; set; } //raised to communicate to parent component that changes have occured with child (this)

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

        protected async Task HandleValidSubmit() //commits to database
        {
            await EmployeeDataService.AddEmployee(Employee);
            ShowDialog = false;

            await CloseEventCallback.InvokeAsync(true); // raises the event callback and uses invokeasync to pass other data (could include added employee here via the parameter)
            StateHasChanged();
        }
    }
}
