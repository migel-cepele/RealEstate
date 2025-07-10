using Microsoft.Extensions.DependencyInjection;
using RealEstate.API.Application.Services;
using RealEstate.API.Infrastructure.Repositories;
using RealEstate.API.Application.Interfaces;

namespace RealEstate.API.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Register repositories
            services.AddScoped<IHouseRepository, HouseRepository>();
            services.AddScoped<IApplicationRepository, ApplicationRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IClientItemRepository, ClientItemRepository>();

            // Register services
            services.AddScoped<HouseService>();
            services.AddScoped<ApplicationService>();
            services.AddScoped<ItemService>();
            services.AddScoped<ClientService>();
            services.AddScoped<UserService>();
            services.AddScoped<ClientItemService>();
            services.AddScoped<LoanService>();
            services.AddScoped<ItemStatisticsService>();
            services.AddScoped<ClientStatisticsService>();

            return services;
        }
    }
}
