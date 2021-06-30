using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorGettingStarted.Shared;

namespace BlazorGettingStarted.Api.Models
{
    public interface IRegionRepository
    {
        IEnumerable<Region> GetAllRegions();
        Region GetRegionById(int regionId);
    }
}
