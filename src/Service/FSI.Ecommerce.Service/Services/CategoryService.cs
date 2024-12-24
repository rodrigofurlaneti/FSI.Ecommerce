using FSI.Ecommerce.Domain.Entities;
using FSI.Ecommerce.Domain.Interfaces;
using FSI.Ecommerce.Service.Dtos;
using FSI.Ecommerce.Service.Interfaces;

namespace FSI.Ecommerce.Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var categorys = await _repository.GetAllAsync();
            return categorys.Select(category => new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                Picture = category.Picture,
                DateInsert = category.DateInsert,
                DateUpdate = category.DateUpdate,
                Status = category.Status
            });
        }

        public async Task<CategoryDto?> GetByIdAsync(int id)
        {
            var categoryEntity = await _repository.GetByIdAsync(id);
            if (categoryEntity == null)
                return null;

            return SetCategoryDto(categoryEntity);
        }

        public async Task AddAsync(CategoryDto CategoryDto)
        {
            var CategoryEntity = SetCategoryEntity_Insert(CategoryDto);
            await _repository.AddAsync(CategoryEntity);
        }


        public async Task UpdateAsync(int id, CategoryDto CategoryDto)
        {
            var CategoryEntity = await _repository.GetByIdAsync(id);
            if (CategoryEntity == null)
                throw new ArgumentException($"Category with ID {id} not found");

            var updatedEntity = SetCategoryEntity_Update(CategoryEntity, CategoryDto);
            await _repository.UpdateAsync(updatedEntity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        // Mapeia de CategoryEntity para CategoryDto
        private CategoryDto SetCategoryDto(CategoryEntity categoryEntity)
        {
            return new CategoryDto
            {
                Id = categoryEntity.Id,
                Name = categoryEntity.Name,
                Description = categoryEntity.Description,
                Picture = categoryEntity.Picture,
                DateInsert = categoryEntity.DateInsert,
                DateUpdate = categoryEntity.DateUpdate,
                Status = categoryEntity.Status
            };
        }

        // Mapeia de CategoryDto para CategoryEntity
        private CategoryEntity SetCategoryEntity(CategoryDto categoryDto)
        {
            return new CategoryEntity
            {
                Id = categoryDto.Id,
                Name = categoryDto.Name,
                Description = categoryDto.Description,
                Picture = categoryDto.Picture,
                DateInsert = categoryDto.DateInsert,
                DateUpdate = categoryDto.DateUpdate,
                Status = categoryDto.Status
            };
        }

        // Cria uma nova entidade para inserção
        private CategoryEntity SetCategoryEntity_Insert(CategoryDto categoryDto)
        {
            return new CategoryEntity
            {
                Name = categoryDto.Name,
                Description = categoryDto.Description,
                Picture = categoryDto.Picture,
                DateInsert = DateTime.Now,
                DateUpdate = DateTime.Now,
                Status = categoryDto.Status
            };
        }

        // Atualiza uma entidade existente com novos dados
        private CategoryEntity SetCategoryEntity_Update(CategoryEntity existingEntity, CategoryDto categoryDto)
        {
            existingEntity.Name = categoryDto.Name;
            existingEntity.Description = categoryDto.Description;
            existingEntity.Picture = categoryDto.Picture;
            existingEntity.DateInsert = categoryDto.DateInsert;
            existingEntity.DateUpdate = DateTime.Now;
            existingEntity.Status = categoryDto.Status;
            return existingEntity;
        }

    }
}
