using BlazorGettingStarted.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorGettingStarted.App.Services
{
    public interface IJobCategoryDataService
    {
        Task<JobCategory> GetJobCategoryById(int jobCategoryId);
        Task<IEnumerable<JobCategory>> GetAllJobCategories();

    }
}
