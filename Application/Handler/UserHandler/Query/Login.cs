using Domain.Interfaces;
using MediatR;
using Application.Dto;
using AutoMapper;

namespace Application.Handler.UserHandler.Query
{
    public class Login : IRequestHandler<LoginUserDto, TokenDto>
    {
        private readonly IUserRepository _repo;
        private readonly IMapper _mapper;

        public Login(IUserRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<TokenDto> Handle(LoginUserDto request, CancellationToken cancellationToken)
        {
            var tokens =  await _repo.Login(request.Email, request.Password);

            var tokenDto = _mapper.Map<TokenDto>(tokens);

            return tokenDto;
        }
    }
}
