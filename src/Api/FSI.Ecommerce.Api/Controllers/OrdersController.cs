using FSI.Ecommerce.Service.Dtos;
using FSI.Ecommerce.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FSI.Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrdersController(IOrderService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _service.GetAllAsync();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var orderDto = await _service.GetByIdAsync(id);
            return Ok(orderDto);
        }

        [HttpPost]
        public async Task<IActionResult> Add(OrderDto orderDto)
        {
            await _service.AddAsync(orderDto);
            return CreatedAtAction(nameof(GetById), new { id = orderDto.Id }, orderDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, OrderDto orderDto)
        {
            await _service.UpdateAsync(id, orderDto);
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
