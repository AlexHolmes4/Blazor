using BlazorGettingStarted.Api.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlazorGettingStarted.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : Controller
    {
        private readonly IRegionRepository _regionRepository;

        public RegionController(IRegionRepository regionRepository)
        {
            _regionRepository = regionRepository;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult GetRegions()
        {
            return Ok(_regionRepository.GetAllRegions());
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult GetRegionById(int id)
        {
            return Ok(_regionRepository.GetRegionById(id));
        }
    }
}
