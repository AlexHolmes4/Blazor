using System.Collections.Generic;
using System.Linq;
using BlazorGettingStarted.Shared;

namespace BlazorGettingStarted.Api.Models
{
    public class RegionRepository : IRegionRepository
    {
        private readonly AppDbContext _appDbContext;

        public RegionRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Region> GetAllRegions()
        {
            return _appDbContext.Regions;
        }

        public Region GetRegionById(int regionId)
        {
            return _appDbContext.Regions.FirstOrDefault(c => c.RegionId == regionId);
        }
    }
}
