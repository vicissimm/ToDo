using Domain.Interfaces;
using Infrastructure.DataContext;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<ToDoAppDataContext>();
            services.AddScoped<ITodoAppContext, ToDoAppDataContext>();
            services.AddScoped<IToDoItemRepository, ToDoItemRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddSingleton<IPasswordHasher, PasswordHasher>();

            services.AddDbContext<ToDoAppDataContext>(options =>
            {
                options.UseNpgsql("Host=127.0.0.1;Password=vv;Persist Security Info=True;Username=postgres;Database=Localhost");
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            return services;    
        }
    }
}
