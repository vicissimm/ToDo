using MediatR;

namespace Application.Dto
{
    public class LoginUserDto : IRequest<TokenDto>
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
