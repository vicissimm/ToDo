namespace Domain.Entites
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsComplete { get; set; } = false;
        public int UserId { get; set; }
        public User? User { get; set; }
      
    }
}
