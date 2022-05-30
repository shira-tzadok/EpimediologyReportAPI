using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using EpidemiologyReport.Services.Repositorieis;
using EpidemiologyReport.Services.Models;

namespace EpidemiologyReport.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationRepository _locationRepository;
        public LocationController(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Location>> GetLocations()
        {
            return await _locationRepository.GetLocations();
        }

        [HttpGet("{city}")]
        public async Task<IEnumerable<Location>> GetLocationByCity(string city)
        {
            return await _locationRepository.GetLocationByCity(city);
        }

        [HttpGet("{id}")]
        public async Task<IEnumerable<Location>> GetLocationByPatientId(int id)
        {
            return await _locationRepository.GetLocationByPatientId(id);
        }

        [HttpPost("{id}")]
        public async Task<ActionResult> AddLocation([FromBody] List<Location> newLocation,[FromRoute] int id)
        {
            Task<IEnumerable<Location>> locations = _locationRepository.AddLocation(newLocation, id);
            if (locations == null)
                return await Task.FromResult(NotFound());
            return await Task.FromResult(Created(id.ToString(),newLocation));
        }

        [HttpDelete("{id}")]
        public async Task<IEnumerable<Location>> DeleteLocationById(int id)
        {
            return await _locationRepository.DeleteLocationById(id);
        }
    }
}
