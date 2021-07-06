using BlazorGettingStarted.App.Services;
using BlazorGettingStarted.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorGettingStarted.ComponentsLibrary.Map;


namespace BlazorGettingStarted.App.Pages
{
    // this class will display employee details; data exposes through service
    public partial class EmployeeDetail
    {
        [Parameter] // blazor will search for the employee ID in the Query String when this component is being invoked.
        public string EmployeeId { get; set; }
        public Employee Employee { get; set; } = new Employee();

        public List<Marker> MapMarkers { get; set; } = new List<Marker>();

        [Inject]
        public IEmployeeDataService EmployeeDataService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Employee = await EmployeeDataService.GetEmployeeDetails(int.Parse(EmployeeId));

            MapMarkers = new List<Marker>
            {
                new Marker{Description = $"{Employee.FirstName} {Employee.LastName}", ShowPopup = false, X = Employee.Longitude, Y = Employee.Latitude}
            };
        }
    }
}
