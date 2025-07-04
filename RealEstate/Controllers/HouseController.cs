using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate.API.Application.Services;
using RealEstate.API.Domain;

namespace RealEstate.API.Controllers
{
    [Route("api/house")]
    [ApiController]
    public class HouseController : ControllerBase
    {
        private readonly HouseService _houseService;

        public HouseController(HouseService houseService)
        {
            _houseService = houseService;
        }

        [HttpGet]
        public IActionResult GetHouses()
        {
            var houses = _houseService.GetHouses();
            return Ok(houses);
        }

        [HttpGet("{id}")]
        public IActionResult GetHouseById(int id)
        {
            var house = _houseService.GetHouseById(id);
            if (house == null)
                return NotFound();
            return Ok(house);
        }

        [HttpPost]
        public IActionResult AddHouse([FromBody] House house)
        {
            var result = _houseService.AddHouse(house);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        
        [HttpPost("filter")]
        public IActionResult GetHousesByFilter([FromBody] Dictionary<string, string> filters)
        {
            var houses = _houseService.Filter(filters);
            return Ok(houses);

        }
    }
}
