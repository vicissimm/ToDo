using Domain.Entites;
using Domain.Interfaces;
using MediatR;

namespace Application.Handler.TodoItem.Query
{
    public class GetTodoItemsQuery: IRequest<List<ToDoItem>>
    {
        public string AccessToken { get; set; }
    }

    public class GetTodoItems : IRequestHandler<GetTodoItemsQuery, List<ToDoItem>>
    {
        private readonly IToDoItemRepository _repo;

        public GetTodoItems(IToDoItemRepository repo)
        {
            _repo = repo;
        }

        async Task<List<ToDoItem>> IRequestHandler<GetTodoItemsQuery, List<ToDoItem>>.Handle(GetTodoItemsQuery request, CancellationToken cancellationToken)
        {
            return (List<ToDoItem>)await _repo.GetItems(request.AccessToken);
        }
    }
}
