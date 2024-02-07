using MediatR;

namespace Application.Dto
{
    public class ToDoItemDto : IRequest
    {
        public int Id { get; private set; }
        public string Name { get; set; } = string.Empty;
        public bool IsComplete { get; private set; }
        public void SetId(int id)
        {
            Id = id;
        }
    }
}
