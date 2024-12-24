using FSI.Ecommerce.Service.Dtos;
using FSI.Ecommerce.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FSI.Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfilesController : ControllerBase
    {
        private readonly IProfileService _service;

        public ProfilesController(IProfileService service)
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
        public async Task<IActionResult> Add(ProfileDto profileDto)
        {
            await _service.AddAsync(profileDto);
            return CreatedAtAction(nameof(GetById), new { id = profileDto.Id }, profileDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProfileDto profileDto)
        {
            await _service.UpdateAsync(id, profileDto);
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
