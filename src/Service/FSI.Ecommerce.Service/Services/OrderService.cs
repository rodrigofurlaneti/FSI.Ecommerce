using FSI.Ecommerce.Domain.Entities;
using FSI.Ecommerce.Domain.Interfaces;
using FSI.Ecommerce.Service.Dtos;
using FSI.Ecommerce.Service.Interfaces;

namespace FSI.Ecommerce.Service.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;

        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<OrderDto>> GetAllAsync()
        {
            var orders = await _repository.GetAllAsync();
            return orders.Select(order => new OrderDto
            {
                Id = order.Id,
                IdCommand = order.IdCommand,
                IdProduct = order.IdProduct,
                Quantity = order.Quantity,
                Discount = order.Discount,
                ValueFor = order.ValueFor,
                ValueOf = order.ValueOf,
                DateInsert = order.DateInsert,
                DateUpdate = order.DateUpdate,
                Status = order.Status
            });
        }

        public async Task<OrderDto?> GetByIdAsync(int id)
        {
            var orderEntity = await _repository.GetByIdAsync(id);
            if (orderEntity == null)
                return null;

            return SetOrderDto(orderEntity);
        }

        public async Task AddAsync(OrderDto OrderDto)
        {
            var OrderEntity = SetOrderEntity_Insert(OrderDto);
            await _repository.AddAsync(OrderEntity);
        }


        public async Task UpdateAsync(int id, OrderDto OrderDto)
        {
            var OrderEntity = await _repository.GetByIdAsync(id);
            if (OrderEntity == null)
                throw new ArgumentException($"Order with ID {id} not found");

            var updatedEntity = SetOrderEntity_Update(OrderEntity, OrderDto);
            await _repository.UpdateAsync(updatedEntity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        // Mapeia de OrderEntity para OrderDto
        private OrderDto SetOrderDto(OrderEntity orderEntity)
        {
            return new OrderDto
            {
                Id = orderEntity.Id,
                IdCommand = orderEntity.IdCommand,
                IdProduct = orderEntity.IdProduct,
                Quantity = orderEntity.Quantity,
                Discount = orderEntity.Discount,
                ValueFor = orderEntity.ValueFor,
                ValueOf = orderEntity.ValueOf,
                DateInsert = orderEntity.DateInsert,
                DateUpdate = orderEntity.DateUpdate,
                Status = orderEntity.Status
            };
        }

        // Cria uma nova entidade para inserção
        private OrderEntity SetOrderEntity_Insert(OrderDto orderDto)
        {
            return new OrderEntity
            {
                IdCommand = orderDto.IdCommand,
                IdProduct = orderDto.IdProduct,
                Quantity = orderDto.Quantity,
                Discount = orderDto.Discount,
                ValueFor = orderDto.ValueFor,
                ValueOf = orderDto.ValueOf,
                DateInsert = DateTime.Now,
                DateUpdate = DateTime.Now,
                Status = orderDto.Status
            };
        }

        // Atualiza uma entidade existente com novos dados
        private OrderEntity SetOrderEntity_Update(OrderEntity existingEntity, OrderDto orderDto)
        {
            existingEntity.Id = orderDto.Id;
            existingEntity.IdCommand = orderDto.IdCommand;
            existingEntity.IdProduct = orderDto.IdProduct;
            existingEntity.Quantity = orderDto.Quantity;
            existingEntity.Discount = orderDto.Discount;
            existingEntity.ValueFor = orderDto.ValueFor;
            existingEntity.ValueOf = orderDto.ValueOf;
            existingEntity.DateInsert = orderDto.DateInsert;
            existingEntity.DateUpdate = DateTime.Now;
            existingEntity.Status = orderDto.Status;
            return existingEntity;
        }
    }
}
