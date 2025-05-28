namespace ToDoWebApplication.Models
{
    public class UserTask
    {
        public ulong Id { get; set; }

        public required string Title { get; set; }

        public string? Description { get; set; }
    }
}
