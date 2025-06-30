using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Interfaces;
using RealEstate.Domain;

namespace RealEstate.Controllers
{
    [Route("api/house")]
    [ApiController]
    public class HouseController : ControllerBase
    {
        private readonly IHouseService _locationService;

        public HouseController(IHouseService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet]
        public IActionResult GetLocations()
        {
            var houses = _locationService.GetHouses();
            return Ok(houses);
        }

        [HttpGet("{id}")]
        public IActionResult GetHouseById(int id)
        {
            var house = _locationService.GetHouseById(id);
            if (house == null)
                return NotFound();
            return Ok(house);
        }

        [HttpPost]
        public IActionResult AddHouse([FromBody] House house)
        {
            var result = _locationService.AddHouse(house);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
