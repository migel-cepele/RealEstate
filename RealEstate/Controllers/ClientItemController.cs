using Microsoft.AspNetCore.Mvc;
using RealEstate.API.Application.Services;
using RealEstate.API.Domain;

namespace RealEstate.API.Controllers
{
    [Route("api/client/item")]
    [ApiController]
    public class ClientItemController : ControllerBase
    {
        private readonly ClientItemService _clientItemService;

        public ClientItemController(ClientItemService clientItemService)
        {
            _clientItemService = clientItemService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var items = _clientItemService.GetAll();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var item = _clientItemService.GetById(id);
            if (item == null)
                return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ClientItem clientItem)
        {
            var result = await _clientItemService.Add(clientItem);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPut]
        public IActionResult Update([FromBody] ClientItem clientItem)
        {
            var result = _clientItemService.Update(clientItem);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var result = _clientItemService.Delete(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPut("inactive")]
        public async Task<IActionResult> Inactive([FromBody] ClientItem clientItem)
        {
            var result = await _clientItemService.UpdateInActive(clientItem);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
