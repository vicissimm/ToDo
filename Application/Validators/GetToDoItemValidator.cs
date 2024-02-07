using Application.Routes;
using FluentValidation;
using Domain.Interfaces;


namespace ToDoApp.Validator
{
    public class GetToDoItemValidator : AbstractValidator<GetItemRoute>
    {
        public GetToDoItemValidator(IToDoItemRepository repos)
        {
            RuleFor(x => x.Id).Must((x, y) =>
            {
                var todoitem = repos.GetItemById(x.Id).Result;

                return todoitem != null;

            }).WithMessage("Todo item doesn't exist");

        }
    }
}
