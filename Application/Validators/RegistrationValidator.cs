using FluentValidation;
using Application.Dto;
using Domain.Interfaces;

namespace Application.Validator
{
    public class RegistrationValidator : AbstractValidator<UserDto>
    {
        private readonly ITodoAppContext _context;
        public RegistrationValidator(ITodoAppContext context)
        {
            _context = context;

            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithMessage("Name is required")
                .NotNull()
                .WithMessage("Name is required");
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email is required.")
                .NotNull()
                .WithMessage("Email is required.")
                .Must(BeUniqueEmail)
                .WithMessage("This email is already in use.");
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is required.")
                .NotNull()
                .WithMessage("Password is required.");
        }

        private bool BeUniqueEmail(string email)
        {
            return !_context.Users.Any(u => u.Email == email);
        }
    }
}
