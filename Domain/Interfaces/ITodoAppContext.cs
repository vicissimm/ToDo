using Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace Domain.Interfaces
{
    public interface ITodoAppContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ToDoItem> ToDoItems { get; set; }
    }
}
