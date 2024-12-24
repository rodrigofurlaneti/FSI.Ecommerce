using FSI.Ecommerce.Domain.Entities;
using FSI.Ecommerce.Domain.Interfaces;
using FSI.Ecommerce.Infrastructure.Data;

namespace FSI.Ecommerce.Infrastructure.Repositories
{
    public class CommandRepository : RepositoryBase<CommandEntity>, ICommandRepository
    {
        public CommandRepository(AppDbContext context) : base(context)
        {
        }
    }
}
