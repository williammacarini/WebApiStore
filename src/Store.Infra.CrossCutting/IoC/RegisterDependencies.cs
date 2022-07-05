using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Store.Domain.Repositories;
using Store.Infra.Data.Context;
using Store.Infra.Data.Repositories;
using Store.Service.Mapper;
using Store.Service.Services;
using Store.Service.Services.Interfaces;

namespace Store.Infra.CrossCutting.IoC
{
    public static class RegisterDependencies
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<StoreContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("Marten")));

            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(MapperEntity));
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
