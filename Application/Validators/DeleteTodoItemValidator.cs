using FluentValidation;
using Domain.Interfaces;
using Application.Routes;

namespace Application.Validator
{
    public class DeleteTodoItemValidator: AbstractValidator<DeleteItemRoute>
    {
        public DeleteTodoItemValidator(IToDoItemRepository _repo)
        {
            RuleFor(x => x.Id).Must((x, y) =>
            {
                var toodItem = _repo.GetItemById(x.Id);

                return toodItem != null;
            }).WithMessage("Todo item does not exist");
        }
    }
}
