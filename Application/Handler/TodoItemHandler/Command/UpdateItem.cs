using AutoMapper;
using Domain.Entites;
using Application.Dto;
using Domain.Interfaces;
using MediatR;

namespace Application.Handler.TodoItem.Command
{
    public class UpdateItemCommand : IRequest
    {
        public ToDoItemDto Item { get; set; } = default!;
        public string AccessToken { get; set; } = string.Empty;
    }

    public class UpdateItem: IRequestHandler<UpdateItemCommand>
    {
        private readonly IToDoItemRepository _repo;
        private readonly IMapper _mapper;
        public UpdateItem(IToDoItemRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
        {
            var item = _mapper.Map<ToDoItem>(request.Item);

            await _repo.UpdateItem(item, request.AccessToken);

            return Unit.Value;
        }
    }
}
