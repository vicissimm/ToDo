using AutoMapper;
using Domain.Interfaces;
using MediatR;
using Application.Routes;

namespace Application.Handler.TodoItem.Command
{
    public class DeleteItemCommand : IRequest
    {
        public DeleteItemRoute ItemId { get; set; } = default!;
        public string AccessToken { get; set; } = string.Empty;
    }

    public class DeleteItem : IRequestHandler<DeleteItemCommand>
    {
        private readonly IToDoItemRepository _repo;
        private readonly IMapper _mapper;
        public DeleteItem(IToDoItemRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
        {
            await _repo.DeleteItem(request.ItemId.Id, request.AccessToken);

            return Unit.Value;
        }
    }
}
