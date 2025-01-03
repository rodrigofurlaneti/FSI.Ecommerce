﻿using FSI.Ecommerce.Service.Interfaces;
using FSI.Ecommerce.Service.Services;

namespace FSI.Ecommerce.Api.DependencyInjection
{
    public static class DependencyInjectionServices
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            // Registro de serviços específicos
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICommandService, CommandService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
