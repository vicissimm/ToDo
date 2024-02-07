using MediatR;

namespace Application.Dto
{
    public class UserDto: IRequest
    {
        public int Id { get; private set; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
       
        public void SetId(int id)
        {
            Id = id;
        }
    }
}
