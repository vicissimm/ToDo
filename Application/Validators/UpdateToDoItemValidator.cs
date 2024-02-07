using FluentValidation;
using Domain.Interfaces;
using Application.Routes;

namespace Application.Validator
{
    public class UpdateToDoItemValidator : AbstractValidator<UpdateItemRoute>
    {
        public UpdateToDoItemValidator(IToDoItemRepository rep)
        {
            RuleFor(x => x.Id).Must((x, y) =>
            {
                var todoitem = rep.GetItemById(y).Result;

                return todoitem != null;

            }).WithMessage("Todo item doesn't exist");
        }
    }
}
