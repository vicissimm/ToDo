
using Microsoft.AspNetCore.Mvc;
using Application.Dto;


namespace ToDoApp.Controllers
{
    public class UserController : BaseController
    {

        [HttpPost]
        
        public async Task<IActionResult> Register([FromBody] UserDto createUser)
        {
            await Mediator.Send(createUser);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginUserDto body)
        {
            var val = await Mediator.Send(body);

            return Ok(val);
        }
    }
}
