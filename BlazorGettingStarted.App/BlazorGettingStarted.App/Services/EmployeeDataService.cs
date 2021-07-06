using BlazorGettingStarted.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorGettingStarted.App.Services
{
    // service implements an interface so that it can be registered with the HttpClientFactory services collection
    public class EmployeeDataService : IEmployeeDataService
    {
        private readonly HttpClient _httpClient;

        public EmployeeDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Employee>> GetLongEmployeeList()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Employee>>($"api/employee/long");
        }

        public async Task<IEnumerable<Employee>> GetTakeLongEmployeeList(int startIndex, int count)
        {
            return await _httpClient.GetFromJsonAsync<List<Employee>>($"api/employee/long/{startIndex}/{count}");
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            //converts employee into JSON
            var employeeJson = new StringContent(JsonSerializer.Serialize(employee), Encoding.UTF8, "application/json");

            //Json string sent with HttpClient via HTTP RESTful method to api endpoint
            var response = await _httpClient.PostAsync("api/employee", employeeJson);

            //if success then employee was added, and we are getting back the added employee.
            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<Employee>(await response.Content.ReadAsStreamAsync());
            }
            return null;
        }
        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Employee>>
                (await _httpClient.GetStreamAsync($"api/employee"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Employee> GetEmployeeDetails(int employeeId)
        {
            return await JsonSerializer.DeserializeAsync<Employee>
                 (await _httpClient.GetStreamAsync($"api/employee/{employeeId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }     

        public async Task UpdateEmployee(Employee employee)
        {
            var employeeJson = new StringContent(JsonSerializer.Serialize(employee), Encoding.UTF8, "application/json");

            await _httpClient.PutAsync("api/employee", employeeJson);
        }

        public async Task DeleteEmployee(int employeeId)
        {
            await _httpClient.DeleteAsync($"api/employee/{employeeId}");
        }

    }
}
