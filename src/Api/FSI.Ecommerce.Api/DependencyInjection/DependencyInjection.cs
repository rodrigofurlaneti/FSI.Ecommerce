using Microsoft.Extensions.DependencyInjection;

namespace FSI.Ecommerce.Api.DependencyInjection
{
    public static class DependencyInjection
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Registrar repositórios
            services.AddRepositories();

            // Registrar serviços
            services.AddServices();
        }
    }
}
