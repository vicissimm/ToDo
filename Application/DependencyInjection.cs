using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Domain.Interfaces;

using TodoAppMappingProfile = Application.MappingProfile.MappingProfile;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddSingleton(provider => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new TodoAppMappingProfile(provider.CreateScope().ServiceProvider.GetService<IPasswordHasher>()));

            }).CreateMapper());

            return services;
        }
    }
}
