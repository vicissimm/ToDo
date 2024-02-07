using Domain.Entites;
using Domain.Interfaces;
using MediatR;
using Application.Dto;
using AutoMapper;

namespace Application.Handler.UserHandler.Command
{

    public class Registration : IRequestHandler<UserDto>
    {
        private readonly IUserRepository _repo;
        private readonly IMapper _mapper;

        public Registration(IUserRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UserDto request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);

            await _repo.CreateUser(user);

            return Unit.Value;
        }
    }
}
