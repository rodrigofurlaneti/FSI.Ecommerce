using FSI.Ecommerce.Service.Dtos;
using FSI.Ecommerce.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FSI.Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommandService _service;

        public CommandsController(ICommandService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var commands = await _service.GetAllAsync();
            return Ok(commands);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var commandDto = await _service.GetByIdAsync(id);
            return Ok(commandDto);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CommandDto commandDto)
        {
            await _service.AddAsync(commandDto);
            return CreatedAtAction(nameof(GetById), new { id = commandDto.Id }, commandDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CommandDto commandDto)
        {
            await _service.UpdateAsync(id, commandDto);
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
