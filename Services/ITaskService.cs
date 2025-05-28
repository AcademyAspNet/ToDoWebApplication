using ToDoWebApplication.Models;

namespace ToDoWebApplication.Services
{
    public interface ITaskService
    {
        List<UserTask> GetTasks();
        void CreateTask(string title, string? description);
        void DeleteTask(ulong id);
        UserTask? GetTask(ulong id);
        void UpdateTask(ulong id, UserTask task);
    }
}
