using FSI.Ecommerce.Service.Dtos;

namespace FSI.Ecommerce.Service.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDto>> GetAllAsync();
        Task<OrderDto?> GetByIdAsync(int id);
        Task AddAsync(OrderDto orderDto);
        Task UpdateAsync(int id, OrderDto orderDto);
        Task DeleteAsync(int id);
    }
}
