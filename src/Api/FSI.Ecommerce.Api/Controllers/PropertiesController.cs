using FSI.Ecommerce.Service.Dtos;
using FSI.Ecommerce.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FSI.Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        private readonly IPropertyService _service;
        public PropertiesController(IPropertyService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var propertys = await _service.GetAllAsync();
            return Ok(propertys);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var propertyDto = await _service.GetByIdAsync(id);
            return Ok(propertyDto);
        }

        [HttpPost]
        public async Task<IActionResult> Add(PropertyDto propertyDto)
        {
            await _service.AddAsync(propertyDto);
            return CreatedAtAction(nameof(GetById), new { id = propertyDto.Id }, propertyDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PropertyDto propertyDto)
        {
            await _service.UpdateAsync(id, propertyDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
