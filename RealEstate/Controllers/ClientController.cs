using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate.API.Application.Services;
using RealEstate.API.Domain;

namespace RealEstate.API.Controllers
{
    [Route("api/client")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ClientService _clientService;

        public ClientController(ClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var items = _clientService.GetAll();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var item = _clientService.GetById(id);
            if (item == null)
                return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Client client)
        {
            var result = _clientService.Add(client);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPut]
        public IActionResult Update([FromBody] Client client)
        {
            var result = _clientService.Update(client);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var result = _clientService.Delete(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("filter")]
        public IActionResult Filter([FromBody] Dictionary<string, string> keyValues, int pageNumber, int pageSize)
        {
            var items = _clientService.Filter(pageNumber, pageSize, keyValues);
            return Ok(items);
        }
    }
}
