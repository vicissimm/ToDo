using MediatR;
using Domain.Interfaces;
using Domain.Entites;
using Application.Dto;
using AutoMapper;

namespace Application.Handler.TodoItem.Command
{

    public class AddItemCommand : IRequest
    {
        public ToDoItemDto Item { get; set; } = default!;
        public string AccessToken { get; set; } = string.Empty;
    }

    public class AddItem : IRequestHandler<AddItemCommand>
    {
        private readonly IToDoItemRepository _repo;
        private readonly IMapper _mapper;
        public AddItem(IToDoItemRepository repo, IMapper mapper )
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(AddItemCommand request, CancellationToken cancellationToken)
        {
            var item = _mapper.Map<ToDoItem>(request.Item);

            await _repo.CreateItem(item, request.AccessToken);

            return Unit.Value;
        }
    }
}
