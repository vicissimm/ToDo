using Microsoft.AspNetCore.Mvc;
using Application.Dto;
using Application.Handler.TodoItem.Command;
using Application.Routes;
using Application.Handler.TodoItem.Query;
using MediatR;


namespace ToDoApp.Controllers
{
    public class ToDoItemController : BaseController
    {
        [HttpPost]

        public async Task<IActionResult> CreateItem([FromBody] ToDoItemDto createItem, [FromHeader] string accessToken)
        {
            var command = new AddItemCommand();
            command.Item = createItem;
            command.AccessToken = accessToken;

            await Mediator.Send(command);

            return Ok();
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteItem(DeleteItemRoute itemId, [FromHeader] string accessToken)
        {
            var command = new DeleteItemCommand();
               
            command.ItemId = itemId;
            command.AccessToken = accessToken;
           

            await Mediator.Send(command);

            return Ok();
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateItem(UpdateItemRoute route, [FromBody] ToDoItemDto item, [FromHeader] string accessToken)
        {
            item.SetId(route.Id);

            var command = new UpdateItemCommand();
            command.Item = item;
            command.AccessToken = accessToken;

            await Mediator.Send(command);

            return Ok();
        }


        [HttpGet("{id}")]


        public async Task<IActionResult> GetItem(GetItemRoute route)
        {
            var query = new GetTodoItemQuery();
            query.Id = route.Id;

            var val = await Mediator.Send(query);

            return Ok(val);
        }

        [HttpGet]

        public async Task<IActionResult> GetItemsOfUser([FromHeader] string accessToken)
        {
            var query = new GetTodoItemsQuery();
            query.AccessToken = accessToken;

            var val = await Mediator.Send(query);

            return Ok(val);
        }
    }
}
