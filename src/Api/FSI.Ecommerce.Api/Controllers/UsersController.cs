using Microsoft.AspNetCore.Mvc;
using FSI.Ecommerce.Service.Interfaces;
using FSI.Ecommerce.Service.Dtos;
using FSI.Ecommerce.Domain.Entities;

namespace FSI.Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;

        public UsersController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _service.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var userDto = await _service.GetByIdAsync(id);
            return Ok(userDto);
        }

        [HttpPost]
        public async Task<IActionResult> Add(UserDto userDto)
        {
            await _service.AddAsync(userDto);
            return CreatedAtAction(nameof(GetById), new { id = userDto.Id }, userDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UserDto userDto)
        {
            await _service.UpdateAsync(id, userDto);
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
