using FluentValidation;
using Application.Dto;

namespace Application.Validator
{
    public class AddTodoItemValidator: AbstractValidator<ToDoItemDto>
    {
        public AddTodoItemValidator() 
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required")
                .NotNull()
                .WithMessage("Name is required");
        }
    }
}
