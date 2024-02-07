using Domain.Entites;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataContext
{
    public class ToDoAppDataContext : DbContext, ITodoAppContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ToDoItem> ToDoItems { get; set; }

        public ToDoAppDataContext(DbContextOptions<ToDoAppDataContext> options) : base(options)
        { 

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDoItem>()
                .Property(x => x.Id)
                .UseIdentityColumn();

            modelBuilder.Entity<User>()
                .Property(u => u.Id)
                .UseIdentityColumn();

            modelBuilder.Entity<ToDoItem>()
                .HasOne(u => u.User)
                .WithMany(i => i.Items)
                .HasForeignKey(u => u.UserId);
        }
    }
}
