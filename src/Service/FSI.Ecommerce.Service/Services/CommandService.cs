using FSI.Ecommerce.Domain.Entities;
using FSI.Ecommerce.Domain.Interfaces;
using FSI.Ecommerce.Service.Dtos;
using FSI.Ecommerce.Service.Interfaces;

namespace FSI.Ecommerce.Service.Services
{
    public class CommandService : ICommandService
    {
        private readonly ICommandRepository _repository;

        public CommandService(ICommandRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<CommandDto>> GetAllAsync()
        {
            var commands = await _repository.GetAllAsync();
            return commands.Select(command => new CommandDto
            {
                Id = command.Id,
                IdUser = command.IdUser,
                DateInsert = command.DateInsert,
                DateUpdate = command.DateUpdate,
                Status = command.Status
            });
        }

        public async Task<CommandDto?> GetByIdAsync(int id)
        {
            var commandEntity = await _repository.GetByIdAsync(id);
            if (commandEntity == null)
                return null;

            return SetCommandDto(commandEntity);
        }

        public async Task AddAsync(CommandDto CommandDto)
        {
            var CommandEntity = SetCommandEntity_Insert(CommandDto);
            await _repository.AddAsync(CommandEntity);
        }


        public async Task UpdateAsync(int id, CommandDto CommandDto)
        {
            var CommandEntity = await _repository.GetByIdAsync(id);
            if (CommandEntity == null)
                throw new ArgumentException($"Command with ID {id} not found");

            var updatedEntity = SetCommandEntity_Update(CommandEntity, CommandDto);
            await _repository.UpdateAsync(updatedEntity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        // Mapeia de CommandEntity para CommandDto
        private CommandDto SetCommandDto(CommandEntity commandEntity)
        {
            return new CommandDto
            {
                Id = commandEntity.Id,
                IdUser = commandEntity.IdUser,
                DateInsert = commandEntity.DateInsert,
                DateUpdate = commandEntity.DateUpdate,
                Status = commandEntity.Status
            };
        }

        // Mapeia de CommandDto para CommandEntity
        private CommandEntity SetCommandEntity(CommandDto commandDto)
        {
            return new CommandEntity
            {
                Id = commandDto.Id,
                IdUser = commandDto.IdUser,
                DateInsert = commandDto.DateInsert,
                DateUpdate = commandDto.DateUpdate,
                Status = commandDto.Status
            };
        }

        // Cria uma nova entidade para inserção
        private CommandEntity SetCommandEntity_Insert(CommandDto commandDto)
        {
            return new CommandEntity
            {
                IdUser = commandDto.IdUser,
                DateInsert = DateTime.Now,
                DateUpdate = DateTime.Now,
                Status = commandDto.Status
            };
        }

        // Atualiza uma entidade existente com novos dados
        private CommandEntity SetCommandEntity_Update(CommandEntity existingEntity, CommandDto commandDto)
        {
            existingEntity.IdUser = commandDto.IdUser;
            existingEntity.DateInsert = commandDto.DateInsert;
            existingEntity.DateUpdate = DateTime.Now;
            existingEntity.Status = commandDto.Status;
            return existingEntity;
        }
    }
}
