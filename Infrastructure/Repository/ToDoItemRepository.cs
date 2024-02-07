using Microsoft.EntityFrameworkCore;
using Domain.Interfaces;
using Domain.Entites;
using Infrastructure.DataContext;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Repository
{
    public class ToDoItemRepository : IToDoItemRepository
    {
        private readonly ToDoAppDataContext context;
        public ToDoItemRepository(ToDoAppDataContext context)
        {
            this.context = context;
        }

        public async Task CreateItem(ToDoItem item, string accessToken)
        {
            int id = GetUserIdFromToken(accessToken);

            item.UserId = id;
            await context.AddAsync(item);

            await context.SaveChangesAsync();
        }

        public async Task UpdateItem(ToDoItem item, string accessToken)
        {
            int id = GetUserIdFromToken(accessToken);

            item.UserId = id;
            context.Update(item);

            await context.SaveChangesAsync();
        }

        public async Task<ToDoItem> GetItemById(int id)
        {
            return await context.ToDoItems.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<ToDoItem>> GetItems(string accessToken)
        {
            int id = GetUserIdFromToken(accessToken);

            return context.ToDoItems.Where(i => i.UserId == id).ToList();
        }

        public async Task DeleteItem(int itemId, string accessToken)
        {
            int id =  GetUserIdFromToken(accessToken);

            var item = await context.ToDoItems.FirstOrDefaultAsync(i => i.Id == itemId);

            context.Remove(item!);

            await context.SaveChangesAsync();
        }

        public int GetUserIdFromToken(string token)
        {
            var configurationManager = new ConfigurationManager();

            var auth = new Authorization(configurationManager);

            var id = auth.DecodeAccessToken(token);

            return id;
        }
    }
}
