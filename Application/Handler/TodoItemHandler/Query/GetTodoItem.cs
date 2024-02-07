using MediatR;
using Domain.Entites;
using Domain.Interfaces;
using AutoMapper;

namespace Application.Handler.TodoItem.Query
{
    public class GetTodoItemQuery : IRequest<ToDoItem>
    {
        public int Id { get; set; }
    }

    public class GetTodoItem : IRequestHandler<GetTodoItemQuery, ToDoItem>
    {
        private readonly IToDoItemRepository _repo;
        private readonly IMapper _mapper;

        public GetTodoItem(IToDoItemRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        async Task<ToDoItem> IRequestHandler<GetTodoItemQuery, ToDoItem>.Handle(GetTodoItemQuery request, CancellationToken cancellationToken)
        {
            var item = await _repo.GetItemById(request.Id);
            var itemGet = _mapper.Map<ToDoItem>(item);
            return itemGet;
        }
    }
}
