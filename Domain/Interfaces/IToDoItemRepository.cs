using Domain.Entites;

namespace Domain.Interfaces
{
    public interface IToDoItemRepository
    {
        public Task<ICollection<ToDoItem>> GetItems(string accessToken);
        public Task<ToDoItem> GetItemById(int id);
        public Task CreateItem(ToDoItem item, string accessToken);
        public Task UpdateItem(ToDoItem item, string accessToken); 
        public Task DeleteItem(int id, string accessToken);
    }
}
