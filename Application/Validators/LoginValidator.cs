using FluentValidation;
using Application.Dto;
using Domain.Interfaces;

namespace Application.Validator
{
    public class LoginValidator : AbstractValidator<LoginUserDto>
    {

        public LoginValidator(ITodoAppContext _context, IPasswordHasher _passwordHasher)
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email is required.")
                .NotNull()
                .WithMessage("Email is required.")
                /*.EmailAddress()
                .WithMessage("Invalid email format.")
                .Must((x, y) =>
                {
                    return _context.Users.Any(u => u.Email == y);
                })*/
                .WithMessage("Email does not exist");
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is required.")
                .NotNull()
                .WithMessage("Password is required.")
                .Must((x, y) =>
                {
                    var user = _context.Users.FirstOrDefault(u => u.Email == x.Email);

                    if(user == null)
                    {
                        return false;
                    }

                    return _passwordHasher.VerifyPassword(user.Password, y);
                })
                .WithMessage("Incorrect password");
        }

    }
}
