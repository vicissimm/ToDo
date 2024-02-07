using AutoMapper;
using Domain.Entites;
using Application.Dto;
using Domain.Interfaces;
using Domain.ValueObjects;

namespace Application.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile(IPasswordHasher passwordHasher)
        {
            CreateMap<ToDoItem, ToDoItemDto>();
            CreateMap<ToDoItemDto, ToDoItem>();
            CreateMap<UserDto, User>().AfterMap((src, dest) => {
                dest.Password = passwordHasher.HashPassword(src.Password);
            });
            CreateMap<User, UserDto>();
            CreateMap<TokenObject, TokenDto>();
        }
    }
}
