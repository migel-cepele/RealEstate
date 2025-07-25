﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate.API.Application.Services;
using RealEstate.API.Domain;

namespace RealEstate.API.Controllers
{
    [Route("api/item")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly ItemService _itemService;

        public ItemController(ItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var items = _itemService.GetAll();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var item = _itemService.GetById(id);
            if (item == null)
                return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Item item, List<ItemImage> itemImages)
        {
            var result = await _itemService.Add(item, itemImages);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPut]
        public IActionResult Update([FromBody] Item item)
        {
            var result = _itemService.Update(item);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var result = _itemService.Delete(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("filter")]
        public IActionResult Filter(int pageNumber, int pageSize, long lastId, [FromBody] Dictionary<string, string> keyValues)
        {
            var items = _itemService.Filter(pageNumber, pageSize, lastId, keyValues);
            return Ok(items);
        }
    }
}
