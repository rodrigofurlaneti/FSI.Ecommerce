using Microsoft.Extensions.DependencyInjection;
using FSI.Ecommerce.Domain.Interfaces;
using FSI.Ecommerce.Infrastructure.Repositories;
using FSI.Ecommerce.Service.Interfaces;
using FSI.Ecommerce.Service.Services;

namespace FSI.Ecommerce.Api
{
    public static class DependencyInjection
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Registrar os serviços e repositórios
            services.AddScoped<IUserService, UserService>();
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
