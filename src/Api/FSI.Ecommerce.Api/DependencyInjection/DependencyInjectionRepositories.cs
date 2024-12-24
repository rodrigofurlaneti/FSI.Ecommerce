using FSI.Ecommerce.Domain.Interfaces;
using FSI.Ecommerce.Infrastructure.Repositories;

namespace FSI.Ecommerce.Api.DependencyInjection
{
    public static class DependencyInjectionRepositories
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            // Registro de repositórios genéricos
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

            // Registro de repositórios específicos
            services.AddScoped<IProfileRepository, ProfileRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
