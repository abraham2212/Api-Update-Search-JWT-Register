using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs.City;
using Services.DTOs.Country;
using Services.Services.Interfaces;

namespace App.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _service;
        public CityController(ICityService service)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(statusCode: StatusCodes.Status201Created)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody]CityCreateDto model)
        {
            await _service.CreateAsync(model);
            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, Type = typeof(CityDto))]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, Type = typeof(CityDto))]
        public async Task<IActionResult> GetById([FromRoute]int? id) => Ok(await _service.GetByIdAsync((int)id));

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, Type = typeof(CityUpdateDto))]
        public async Task<IActionResult> Update([FromRoute] int? id, [FromBody]CityUpdateDto model)
        {
            await _service.UpdateAsync((int)id, model);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete([FromRoute] int? id)
        {
            await _service.DeleteAsync((int)id);
            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> SoftDelete([FromRoute] int? id)
        {
            await _service.SoftDeleteAsync((int)id);
            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Search(string searchtext) => Ok(await _service.SearchAsync(searchtext));
    }
}
