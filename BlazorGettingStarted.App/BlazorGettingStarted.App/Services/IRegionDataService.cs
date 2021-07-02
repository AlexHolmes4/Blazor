using BlazorGettingStarted.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGettingStarted.App.Services
{
    public interface IRegionDataService
    {
        Task<IEnumerable<Region>> GetAllRegions();
        Task<Region> GetRegionById(int regionId);
    }
}
