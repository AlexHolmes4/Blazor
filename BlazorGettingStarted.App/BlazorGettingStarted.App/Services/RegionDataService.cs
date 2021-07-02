using BlazorGettingStarted.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorGettingStarted.App.Services
{
    public class RegionDataService : IRegionDataService
    {
        private readonly HttpClient _httpClient;

        public RegionDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Region>> GetAllRegions()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Region>>
                (await _httpClient.GetStreamAsync($"api/region"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Region> GetRegionById(int regionId)
        {
            return await JsonSerializer.DeserializeAsync < Region >
                (await _httpClient.GetStreamAsync($"api/region/{regionId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }); 
        }
    }
}
