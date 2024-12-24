using FSI.Ecommerce.Domain.Entities;
using FSI.Ecommerce.Domain.Interfaces;
using FSI.Ecommerce.Service.Dtos;
using FSI.Ecommerce.Service.Interfaces;

namespace FSI.Ecommerce.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var products = await _repository.GetAllAsync();
            return products.Select(product => new ProductDto
            {
                Id = product.Id,
                IdCategory = product.IdCategory,
                Name = product.Name,
                Description = product.Description,
                Details = product.Details,
                Picture = product.Picture,
                Amount = product.Amount,
                ValueOf = product.ValueOf,
                ValueFor = product.ValueFor,
                Discount = product.Discount,
                DateInsert = product.DateInsert,
                DateUpdate = product.DateUpdate,
                Status = product.Status
            });
        }

        public async Task<ProductDto?> GetByIdAsync(int id)
        {
            var productEntity = await _repository.GetByIdAsync(id);
            if (productEntity == null)
                return null;

            return SetProductDto(productEntity);
        }

        public async Task AddAsync(ProductDto ProductDto)
        {
            var ProductEntity = SetProductEntity_Insert(ProductDto);
            await _repository.AddAsync(ProductEntity);
        }


        public async Task UpdateAsync(int id, ProductDto ProductDto)
        {
            var ProductEntity = await _repository.GetByIdAsync(id);
            if (ProductEntity == null)
                throw new ArgumentException($"Product with ID {id} not found");

            var updatedEntity = SetProductEntity_Update(ProductEntity, ProductDto);
            await _repository.UpdateAsync(updatedEntity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        // Mapeia de ProductEntity para ProductDto
        private ProductDto SetProductDto(ProductEntity productEntity)
        {
            return new ProductDto
            {
                Id = productEntity.Id,
                IdCategory = productEntity.IdCategory,
                Name = productEntity.Name,
                Description = productEntity.Description,
                Details = productEntity.Details,
                Picture = productEntity.Picture,
                Amount = productEntity.Amount,
                ValueOf = productEntity.ValueOf,
                ValueFor = productEntity.ValueFor,
                Discount = productEntity.Discount,
                DateInsert = productEntity.DateInsert,
                DateUpdate = productEntity.DateUpdate,
                Status = productEntity.Status
            };
        }

        // Cria uma nova entidade para inserção
        private ProductEntity SetProductEntity_Insert(ProductDto productDto)
        {
            return new ProductEntity
            {
                Id = productDto.Id,
                IdCategory = productDto.IdCategory,
                Name = productDto.Name,
                Description = productDto.Description,
                Details = productDto.Details,
                Picture = productDto.Picture,
                Amount = productDto.Amount,
                ValueOf = productDto.ValueOf,
                ValueFor = productDto.ValueFor,
                Discount = productDto.Discount,
                DateInsert = DateTime.Now,
                DateUpdate = DateTime.Now,
                Status = productDto.Status
            };
        }

        // Atualiza uma entidade existente com novos dados
        private ProductEntity SetProductEntity_Update(ProductEntity existingEntity, ProductDto productDto)
        {
            existingEntity.IdCategory = productDto.IdCategory;
            existingEntity.Name = productDto.Name;
            existingEntity.Description = productDto.Description;
            existingEntity.Details = productDto.Details;
            existingEntity.Picture = productDto.Picture;
            existingEntity.Amount = productDto.Amount;
            existingEntity.ValueOf = productDto.ValueOf;
            existingEntity.ValueFor = productDto.ValueFor;
            existingEntity.Discount = productDto.Discount;
            existingEntity.DateInsert = productDto.DateInsert;
            existingEntity.DateUpdate = DateTime.Now;
            existingEntity.Status = productDto.Status;
            return existingEntity;
        }
    }
}
